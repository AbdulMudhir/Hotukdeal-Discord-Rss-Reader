namespace Hotukdeal
{


    public class Deal
    {


        private string _name;

        private string _price;

        private string _category;

        private string _link;


        private string _description;

        private string _imageLink;

        public string Name { get => _name; set => _name = value; }
        public string Price { get => _price; set => _price = value; }
        public string Category { get => _category; set => _category = value; }
        public string Link { get => _link; set => _link = value; }
        public string Description { get => _description; set => _description = value; }
        public string ImageLink { get => _imageLink; set => _imageLink = value; }

        public Deal(string name, string price, string category, string link, string description, string imageLink)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
            this.Link = link;
            this.Description= description ;
            this.ImageLink = imageLink;




        }




    }




}
