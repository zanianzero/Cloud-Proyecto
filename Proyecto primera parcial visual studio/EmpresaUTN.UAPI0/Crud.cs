using System.Net;
using System.Text.Json.Nodes;

namespace EmpresaUTN.UAPI
{
 
    //hacer un crud para cada entidad
    public class Crud<T>
    {
        public T[] Select(String Url)
        {
            try 
            {               
                using (var api = new WebClient())
                {
                api.Headers.Add("Content-Type", "application/json");
                var json = api.DownloadString(Url);
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T[]>(json);
                return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("HA SUCEDIDO UN ERROR INESPERADO("+ex.Message+")");
            }
        }










        /////////////////////////////////////////////////esete id no se sabe si es string o no 
        //select por id del objeto T
        public T SelectById(string Url, string id)
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-Type", "application/json");
                    var json = api.DownloadString(Url + "/" + id);
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("HA SUCEDIDO UN ERROR INESPERADO(" + ex.Message + ")");
            }

        }   


        public void Update(string Url,string id, T data)
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-Type", "application/json");
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    api.UploadString(Url + "/" + id, "PUT", json);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("HA SUCEDIDO UN ERROR INESPERADO(" + ex.Message + ")");
            }

        }

        //insertar un objeto T
        public T Insert(string Url, T data)
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-Type", "application/json");
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    json = api.UploadString(Url, "POST", json);
                    data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("HA SUCEDIDO UN ERROR INESPERADO(" + ex.Message + ")");
            }
        }

        //delete por id
        public void Delete(string Url, string id)
        {
            try 
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-Type", "application/json");
                    api.UploadString(Url + "/" + id, "DELETE", "");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("HA SUCEDIDO UN ERROR INESPERADO(" + ex.Message + ")");
            }
        }




    }
}