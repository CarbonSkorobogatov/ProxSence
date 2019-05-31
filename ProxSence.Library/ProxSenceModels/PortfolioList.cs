using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProxSence.Library.ProxSenceModels
{
    public class PortfolioList
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Отсутствует имя проекта")]
        public string ProjectName { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="Отсутствует описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Отсутствует категория")]
        public string ProjectCategory { get; set; }
        public byte[] Images { get; set; }
        public string ImageType { get; set; }
    }
}
