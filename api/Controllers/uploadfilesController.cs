using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Metal.Models;

namespace Metal.Controllers
{
    public class uploadfilesController : ApiController
    {
        [HttpPost]
        [Route("api/uoloadfile/{idOrdenTrabajo}")]
        public IHttpActionResult uploadfile(int idOrdenTrabajo)
        {
            var i = 0;
            var uploadedFileNames = new List<string>();
            string result = string.Empty;

            HttpResponseMessage response = new HttpResponseMessage();

            var httpRequest = System.Web.HttpContext.Current.Request;

            if (httpRequest.Files.Count <= 0)
            {
                return Json(500);
            }

            var postedFile = httpRequest.Files[i];

            using (var random = new Helpers.Random())
            {
                var fileSave = random.GenerateRandom(true, true, true, false, 12) + Path.GetExtension(postedFile.FileName);

                var filePath = HttpContext.Current.Server.MapPath("~/UploadedFiles/" + fileSave);
                try
                {
                    postedFile.SaveAs(filePath);
                    uploadedFileNames.Add(httpRequest.Files[i].FileName);

                    CreateFile(postedFile.FileName, fileSave, idOrdenTrabajo);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return Json(200);
            }
        }

        
        private void CreateFile(string nombreReal, string nombreFisico, int idOrdenTrabajo)
        {
            var model = new archivos();
            model.nombreReal = nombreReal;
            model.nombreFisico = nombreFisico;
            model.idOrdenTrabajo = idOrdenTrabajo;

            using (var db = new metalEntities())
            {
                db.archivos.Add(model);
                db.SaveChanges();
            }
        }
    }
}

