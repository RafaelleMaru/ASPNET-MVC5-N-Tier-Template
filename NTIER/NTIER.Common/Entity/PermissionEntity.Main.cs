using NTIER.Common.Interface;
using Rafaelle.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTIER.Common.Entity
{
    public partial class PermissionEntity : ModelBase, IPermission, IValidatable
    {
        private bool _add;
        private bool _edit;
        private bool _delete;
        private bool _view;
        private bool _listView;
        private bool _approve;
        private bool _download;
        private bool _upload;

        public bool Add
        {
            get { return _add; }
            set { _add = value; }
        }


        public bool Edit
        {
            get { return _edit; }
            set { _edit = value; }
        }

        public bool Delete
        {
            get { return _delete; }
            set { _delete = value; }
        }

        public bool View
        {
            get { return _view; }
            set { _view = value; }
        }

        public bool ListView
        {
            get { return _listView; }
            set { _listView = value; }
        }

        public bool Approve
        {
            get { return _approve; }
            set { _approve = value; }
        }

        public bool Download
        {
            get { return _download; }
            set { _download = value; }
        }

        public bool Upload
        {
            get { return _upload; }
            set { _upload = value; }
        }
        
    }
}
