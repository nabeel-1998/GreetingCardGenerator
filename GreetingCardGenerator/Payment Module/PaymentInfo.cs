using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingCardGenerator.Payment_Module
{
    public class PaymentInfo
    {
        private int cardNumber { get; set; }
        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }
        private int cvc { get; set; }

        public string CardNumber
        {
            get { return CryptoEngine.Encrypt
                    (cardNumber.ToString(), 
                    Helper.InMemoryInfoHolder.UserId.ToString()); 
                }
            set { cardNumber = Convert.ToInt32(value); }
        }

        public string Cvc 
        {
            get
            {
                return CryptoEngine.Encrypt(cvc.ToString(), Helper.InMemoryInfoHolder.UserId.ToString());
            }
            set
            {
                cvc = Convert.ToInt16(value);
            }
        }

    }
}
