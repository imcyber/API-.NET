using System;

namespace api.domain.Models
{
    public class UserModels
    {
        private Guid _Id;
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set { _createAt = value; }
        }
        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }

    }
}
