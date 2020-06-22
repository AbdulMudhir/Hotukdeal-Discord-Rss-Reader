namespace Hotukdeal
{


    public class Deal
    {


        private string _name;

        private string _price;

        private string _category;

        private string _link;


        private string _merchantName;

        private string _directLink;
        



        private string _description;

        private string _imageLink;

        private string _hotMeter;

        private string _comments;

        
        private string _postedDate;

        private string _madeHot;
        private string _categoryImage;


        public string Name { get => _name;  }
        public string Price { get => _price; }


        public string Category { get => _category; }
        public string Link { get => _link;  }
        public string Description { get => _description;  }
        public string ImageLink { get => _imageLink;  }
        public string MerchantName { get => _merchantName; }
        public string DirectLink { get => _directLink; }
        public string HotMeter { get => _hotMeter; }
        public string Comments { get => _comments; }
        public string PostedDate { get => _postedDate; }
        public string MadeHot { get => _madeHot;}
        public string CategoryImage { get => _categoryImage;}

        public Deal(string name, string price, string category, string link, string merchantName, string directLink, string description, string imageLink, string hotMeter, string comments, string postedDate, string madeHot, string categoryImage)
        {
            _name = name;
            _price = price;
            _category = category;
            _link = link;
            _merchantName = merchantName;
            _directLink = directLink;
            _description = description;
            _imageLink = imageLink;
            _hotMeter = hotMeter;
            _comments = comments;
            _postedDate = postedDate;
            _madeHot = madeHot;
            _categoryImage = categoryImage;
        }





    }




}
