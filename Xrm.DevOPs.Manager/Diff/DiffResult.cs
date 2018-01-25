using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.DevOPs.Manager.Diff
{
    class DiffResult
    {
        public List<EntityDiffResult> Entities = new List<EntityDiffResult>();
        public List<ComponentDiff<Entity>> Workflows = new List<ComponentDiff<Entity>>();
        public List<ComponentDiff<Entity>> Plugins = new List<ComponentDiff<Entity>>();
        public List<ComponentDiff<Entity>> SdkMessageProcessingSteps = new List<ComponentDiff<Entity>>();
        public List<ComponentDiff<Entity>> Templates = new List<ComponentDiff<Entity>>();
    }

    public class EntityDiffResult
    {
        public EntityDiffResult(EntityInfo ei)
        {
            EntityInfo = ei;
        }
        public EntityInfo EntityInfo { get; set; }
        public List<ComponentDiff<AttributeMetadata>> Attributes { get; set; } = new List<ComponentDiff<AttributeMetadata>>();
        public List<ComponentDiff<OneToManyRelationshipMetadata>> OneToManyRelationships = new List<ComponentDiff<OneToManyRelationshipMetadata>>();
        public List<ComponentDiff<ManyToManyRelationshipMetadata>> ManyToManyRelationships = new List<ComponentDiff<ManyToManyRelationshipMetadata>>();
        public List<ComponentDiff<Entity>> Forms = new List<ComponentDiff<Entity>>();
        public List<ComponentDiff<Entity>> Views = new List<ComponentDiff<Entity>>();

        internal bool IsEmpty()
        {
            return Attributes.Count == 0 && OneToManyRelationships.Count == 0 && ManyToManyRelationships.Count == 0 && Forms.Count == 0;
        }
    }

    public class ComponentDiff<T>
    {
        public string Key { get; set; }
        public string EntityName { get; set; }
        public string Name { get; set; }
        public T Left { get; set; }
        public T Right { get; set; }

        public int LRI { get; set; }
    }
}
