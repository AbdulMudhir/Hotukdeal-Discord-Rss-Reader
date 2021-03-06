namespace Hotukdeal
{


    public class DealBuilder
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

        public DealBuilder Name(string name)
        {

            _name = name;

            return this;
        }

        public DealBuilder Price(string price)
        {
            _price = price;
            return this;
        }

        public DealBuilder Category(string category)
        {

            _category = category;
            return this;
        }


        public DealBuilder Link(string Link)
        {
            _link = Link;
            return this;
        }

        public DealBuilder Description(string description)
        {
            _description = description;
            return this;
        }


        public DealBuilder ImageLink(string imageLink)
        {
            _imageLink = imageLink;
            return this;
        }

        public DealBuilder MerchantName(string merchantName)
        {
            _merchantName = merchantName;
            return this;
        }

        public DealBuilder DirectLink(string directLink)
        {
            _directLink = directLink;
            return this;
        }
        public DealBuilder HotMeter(string hotMeter)
        {
            _hotMeter = hotMeter;
            return this;
        }

        public DealBuilder Comment(string comment)
        {
            _comments = comment;
            return this;
        }

        public DealBuilder PostedDate(string postedDate)
        {
            _postedDate = postedDate;
            return this;
        }

        public DealBuilder MadeHot(string madeHot)
        {
            _madeHot = madeHot;
            return this;
        }

        public DealBuilder CategoryImage(string image)
        {
            _categoryImage = image;
            return this;
        }

        public Deal Build()
        {
            Deal deal = new Deal(_name, _price, _category, _link, _merchantName, _directLink, _description, _imageLink, _hotMeter, _comments, _postedDate, _madeHot, _categoryImage);
            return deal;

        }


    }




}
