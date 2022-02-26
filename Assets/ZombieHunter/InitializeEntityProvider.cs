using System;
using Voody.UniLeo;

namespace ZombieHunter
{
    public class InitializeEntityProvider : MonoProvider<InitializeEntityRequest>
    { } 
    
    [Serializable]
    public struct InitializeEntityRequest
    {
        public EntityReference EntityReference;
    }
}