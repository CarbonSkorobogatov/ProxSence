using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProxSence.Library.ProxSenceModels
{
    public class FeedbackModel
    {
        [Required(ErrorMessage = "Пропущено поле имени")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана почта для обратной связи")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }

        private string subject;
        [Required(ErrorMessage = "Не указана тема сообщения")]
        public string Subject 
        {
            get 
            {
                return subject;
            }
            set 
            { 
                subject = "PSe | " + value;
            }
        }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Сообщение не может быть пустым")]
        public string Message { get; set; }
    }
}