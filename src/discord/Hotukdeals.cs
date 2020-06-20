
using System.Collections.Generic;

namespace Hotukdeal
{



  public class  Hotukdeals
    {

        public List<Deal> deals {get;set;} = new List<Deal>();


        public int Total{get{return deals.Count;}}


    public Hotukdeals()
    {

    }

        public void addDeal(Deal deal)
        {
          deals.Add(deal);
          
        }


        public void removeDeal(Deal deal)
        {

          deals.Remove(deal);

        }








    }







}