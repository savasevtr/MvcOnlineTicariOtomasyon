using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class QRController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string kod)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qRCode = qRCodeGenerator.CreateQrCode(kod, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap bitmap = qRCode.GetGraphic(10))
                {
                    bitmap.Save(memoryStream, ImageFormat.Png);
                    ViewBag.qRCodeImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                }
            }

            return View();
        }
    }
}