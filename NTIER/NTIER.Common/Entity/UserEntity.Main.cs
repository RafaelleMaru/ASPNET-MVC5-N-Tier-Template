using NTIER.Common.Interface;
using Rafaelle.Framework;
using System;
using System.Collections.Specialized;

namespace NTIER.Common.Entity
{
    public partial class UserEntity : ModelBase, IUserEntity, IValidatable
    {
        #region > Variables


        private Guid _userId;
        private byte _userTypeId;
        private string _username;
        private string _password;
        private string _salt;
        private string _securityStamp;
        private string _email;
        private string _firstname;
        private string _lastname;
        private string _middlename;
        private bool _active;
        private DateTime _created;
        private string _createdBy;
        private DateTime _updated;
        private string _updatedBy;
        private byte[] _timestamp;

        #endregion


        #region > Constructors

        public UserEntity()
        {

        }

        public UserEntity(Guid userId,
            byte userTypeId,
            string username,
            string password,
            string salt,
            string securityStamp,
            string email,
            string firstname,
            string lastname,
            string middlename,
            bool active,
            DateTime created,
            string createdBy,
            DateTime updated,
            string updatedBy,
            byte[] timestamp)
        {
            _userId = userId;
            _userTypeId = userTypeId;
            _username = username;
            _password = password;
            _salt = salt;
            _securityStamp = securityStamp;
            _email = email;
            _firstname = firstname;
            _lastname = lastname;
            _middlename = middlename;
            _active = active;
            _created = created;
            _createdBy = createdBy;
            _updated = updated;
            _updatedBy = updatedBy;
            _timestamp = timestamp;

        }

        public UserEntity(NameValueCollection form)
        {
            UserId = new Guid(form["userId"]);
            UserTypeId = Convert.ToByte(form["userTypeId"]);
            Username = form["username"];
            Password = form["password"].Trim();
            Salt = form["salt"].Trim();
            Salt = form["securityStamp"].Trim();
            Email = form["email"];
            Firstname = form["firstname"];
            Lastname = form["lastname"];
            Middlename = form["middlename"];
            Active = Convert.ToBoolean(form["active"]);
            Created = Convert.ToDateTime(form["created"]);
            CreatedBy = form["createdBy"];
            Updated = Convert.ToDateTime(form["updated"]);
            UpdatedBy = form["updatedBy"];
            Timestamp = Convert.FromBase64String(form["timestamp"]);
        }

        #endregion

        #region Properties

        public Guid UserId
        {
            get => _userId;

            set => _userId = value;
        }

        public byte UserTypeId
        {
            get
            {
                return _userTypeId;
            }

            set
            {
                _userTypeId = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Salt
        {
            get
            {
                return _salt;
            }

            set
            {
                _salt = value;
            }
        }

        public string SecurityStamp
        {
            get
            {
                return _securityStamp;
            }

            set
            {
                _securityStamp = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Firstname
        {
            get
            {
                return _firstname;
            }

            set
            {
                _firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return _lastname;
            }

            set
            {
                _lastname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return _middlename;
            }

            set
            {
                _middlename = value;
            }
        }

        public bool Active
        {
            get
            {
                return _active;
            }

            set
            {
                _active = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return _created;
            }

            set
            {
                _created = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return _createdBy;
            }

            set
            {
                _createdBy = value;
            }
        }

        public DateTime Updated
        {
            get
            {
                return _updated;
            }

            set
            {
                _updated = value;
            }
        }

        public string UpdatedBy
        {
            get
            {
                return _updatedBy;
            }

            set
            {
                _updatedBy = value;
            }
        }

        public byte[] Timestamp
        {
            get
            {
                return _timestamp;
            }

            set
            {
                _timestamp = value;
            }
        }




        #endregion

        #region MaxLength



        public int UsernameMaxLength
        {
            get
            {
                return 120;
            }
        }

        public int PasswordMaxLength
        {
            get
            {
                return 128;
            }
        }

        public int SaltMaxLength
        {
            get
            {
                return 8;
            }
        }

        public int EmailMaxLength
        {
            get
            {
                return 120;
            }
        }

        public int FirstnameMaxLength
        {
            get
            {
                return 120;
            }
        }

        public int LastnameMaxLength
        {
            get
            {
                return 120;
            }
        }

        public int MiddlenameMaxLength
        {
            get
            {
                return 120;
            }
        }

        public int CreatedByMaxLength
        {
            get
            {
                return 120;
            }
        }

        public int UpdatedByMaxLength
        {
            get
            {
                return 120;
            }
        }


        #endregion

    }
}
