using MvcClienteApiCrudDoctores.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcClienteApiCrudDoctores.Services
{
    public class ServiceApiDoctor
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;
        public ServiceApiDoctor(IConfiguration configuration)
        {
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiDoctores");
        }
        private async Task<T> CallApiAsync<T> (string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            string request = "api/doctor";
            List<Doctor> data = await this.CallApiAsync<List<Doctor>>(request);
            return data;
        }
        public async Task<Doctor> FindDoctor(int id)
        {
            string request = "api/doctor/" + id;
            Doctor data = await this.CallApiAsync<Doctor>(request);
            return data;
        }
        public async Task DeleteDoctor(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/doctor/" + id;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage response = await client.DeleteAsync(request);

            }
        }
        public async Task InsertDocotr(int id, string apellido, string especialidad, int salario, int idhospital)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "api/doctor";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Doctor doc = new Doctor();
                doc.IdDoctor = id;
                doc.Apellido = apellido;
                doc.Especialidad = especialidad;
                doc.Salario = salario;
                doc.IdHospital = idhospital;
                string json = JsonConvert.SerializeObject(doc);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(request, content);
                    
            }
        }
        public async Task UpdateDoctor(int id, string apellido, string especialidad, int salario, int idhospital)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/doctor";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Doctor doc = new Doctor();
                doc.IdDoctor = id;
                doc.Apellido = apellido;
                doc.Especialidad = especialidad;
                doc.Salario = salario;
                doc.IdHospital = idhospital;
                string json = JsonConvert.SerializeObject(doc);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(request, content);

            }
        }
    }
}
