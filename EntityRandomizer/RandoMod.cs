using KHMI;
using KHMI.Types;
using System.Numerics;

namespace EntityRandomizer
{
    public class RandoMod : KHMod
    {
        public RandoMod(ModInterface modInterface) : base(modInterface) { }

        public override void playerLoaded(Entity newPlayer)
        {
            IntPtr etStart = modInterface.memoryInterface.nameToAddress("FirstEntity");
            IntPtr etEndPtr = modInterface.memoryInterface.nameToAddress("FinalEntityPtr");
            IntPtr etEnd = (IntPtr)modInterface.memoryInterface.readLong(etEndPtr);
            EntityTable et = new EntityTable(modInterface.dataInterface, etStart, etEnd);

            Entity[] entities = et.Entities;
            Vector3[] positions = new Vector3[entities.Length];
            for(int i = 0; i < positions.Length; i++)
            {
                positions[i] = entities[i].Position;
            }
            Random r = new Random();
            r.Shuffle(positions);
            for(int i = 0; i < entities.Length; i++)
            {
                entities[i].Position = positions[i];
            }
        }
    }
}
