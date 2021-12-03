using Spese.Core.BusinessLayer;
using Spese.Spese.Core.BusinessLayer;
using Spese.Core.Interfaces;
using Spese.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spese.Spese.Mock.Repositories;
using Spese.Spese.Core.Models;

namespace Spese.Spese.Client
{
    internal class Menu
    {
        private static readonly PurchaseBL mainPBL = new PurchaseBL(new MockPurchaseRepo(), new MockUserRepo(), new MockCategoryRepo());

        internal static void Start()
        {

            char choice;
            do
            {
                Console.WriteLine("1 aggiungi spesa" +
                                  "\n2 Approvare una spesa" +
                                  "\n3 visualizza spese approvate nel mese precedente" +
                                  "\n4 visualizza le spese di un utente" +
                                  "\n5 visualizza totale spese per categoria con data al mese precedente" +
                                  "\n6 visualizza spese dalla più recente alla meno recente");

                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        AddPurchase();
                        break;
                    case '2':
                        ApproveP();
                        
                        break;
                    case '3':
                        ViewPurchasesLastMonth();
                        
                        
                        break;
                    case '4':
                        ViewPurchasesOfUser();
                        break;
                    case '5':
                        ViewAmountPurchasesByCat();
                        break;
                    case '6':
                        ViewPurchasesOrdered();
                        break;
                    case 'q':
                         
                        break;
                    default:
                        Console.WriteLine("Scelta non disponibile");
                        break;

                }
            } while (!(choice == 'q'));

            

        }

        private static void ViewPurchasesOrdered()
        {
            IEnumerable<Purchase> purchases = mainPBL.ViewPurchasesOrdered();
            throw new NotImplementedException();
        }

        private static void ViewAmountPurchasesByCat()
        {
            int id;
            IEnumerable<Purchase> purchases;
            Console.WriteLine("Inserire id della categoria di spesa");
            if (!(int.TryParse(Console.ReadLine(), out id)))
            {
                Console.WriteLine("Inserire ID valido");
            };
            //string validId= isValidId(int id);   metodo per controllare se l'id è presente nella lista categories su InMemoryStorage
            //if (valid)
            //{

            //}
           
            throw new NotImplementedException();
        }

        private static void AddPurchase()
        {
            throw new NotImplementedException();
        }

        private static void ViewPurchasesOfUser()
        {
            int id;
            Console.WriteLine("Inserire id dell'utente");
            if (!(int.TryParse(Console.ReadLine(), out id)))
            {
                Console.WriteLine("Inserire ID valido");
            };

            IEnumerable<Purchase> purchases = mainPBL.ViewPurchasesOfUser(id);
            throw new NotImplementedException();
        }

        private static void ViewPurchasesLastMonth()
        {
            IEnumerable<Purchase> purchases = mainPBL.ViewPurchasesLastMonth();
            foreach (Purchase purchase in purchases)
            {
                purchase.ToString();
            }

            throw new NotImplementedException();
        }

        private static void ApproveP()
        {
            Console.WriteLine("Inserire Id della spesa da approvare");
            int id;
            if(!( int.TryParse(Console.ReadLine(), out id))){
                Console.WriteLine("Inserire ID valido");
            };

            Purchase p = mainPBL.ApproveP(id);
            p.ToString();
        }



    }
}
