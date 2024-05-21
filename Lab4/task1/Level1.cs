using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    
    class Level1 : SupportHandler
    {
        // Перевірка, чи запит пов'язаний з відображенням каналів на телевізорі
        public override void HandleRequest(string question)
        {
            if (question.Contains("displaying channels on the TV"))
            {
                Console.WriteLine("Check the antenna cable connection and restart the TV.");
            }
            else
            {
                // Якщо не пов'язаний, передаємо запит наступному обробнику у ланцюжку
                successor.HandleRequest(question);
            }
        }
    }
}
