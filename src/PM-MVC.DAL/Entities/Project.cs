using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace PMMVC.DAL.Entities
{
    [DataContract]
    public class Project
    {
        #region private variables

        private int m_id;
        private string m_description;
        private bool m_active;
        private DateTime m_createdDate;

        #endregion

        #region properties

        [DataMember]
        public int ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [DataMember]
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }

        [DataMember]
        public bool Active
        {
            get { return m_active; }
            set { m_active = value; }
        }

        [DataMember]
        public DateTime CreatedDate
        {
            get { return m_createdDate; }
            set { m_createdDate = value; }
        }

        #endregion
    }
}
