using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;

using Xrm.DevOPs.ComponentModel;
using Xrm.DevOPs.Manager.Helpers;
using static Xrm.DevOPs.ComponentModel.EnumTypes;

namespace Xrm.DevOPs.Manager.Wrappers
{
    public class CrmOrganization : CrmComponent
    {
        public List<OptionSetMetadataBase> _optionSets;
        public string Name { get; set; }
        public IOrganizationService Service { get; set; }

        public TreeNodeType Type { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public List<OptionSetMetadataBase> OptionSets
        {
            get
            {
                if (_optionSets == null)
                    _optionSets = MetadataHelper.GetOptionSetMetadata(Service);

                return _optionSets;
            }
        }


    }

    public class CrmEntityColumn
    {
        #region Private Fields

        private string m_label;
        private string m_name;
        private Type m_type;

        #endregion Private Fields

        #region Public Constructors

        public CrmEntityColumn(string name, string label, Type type)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            m_name = name;
            m_label = label;
            m_type = type;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Label
        {
            get
            {
                return m_label;
            }
        }

        public string Name
        {
            get
            {
                return m_name;
            }
        }

        public Type Type
        {
            get
            {
                return m_type;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public override string ToString()
        {
            return Name;
        }

        #endregion Public Methods
    }

    public interface ICrmEntity
    {
        #region Public Properties

        Guid EntityId { get; }
        string EntityType { get; }
        bool IsSystemCrmEntity { get; }
        Dictionary<string, object> Values { get; }

        #endregion Public Properties

        #region Public Methods

        Dictionary<string, object> GenerateCrmEntities();

        void UpdateDates(DateTime? createdOn, DateTime? modifiedOn);

        #endregion Public Methods
    }
}
