
using Sandbox;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[Library( "npc_test", Title = "Npc Test" )]
public partial class NpcTest : AnimatedEntity
{

	public Vector3 EyePosition => Position + Vector3.Up * 64;

	[ConCmd.Server( "npc_clear" )]
	public static void NpcClear()
	{
		foreach ( var npc in Entity.All.OfType<NpcTest>().ToArray() )
			npc.Delete();
	}

	float Speed;


	public override void Spawn()
	{
		base.Spawn();

		SetModel( "models/citizen/citizen.vmdl" );
		SetupPhysicsFromCapsule( PhysicsMotionType.Keyframed, Capsule.FromHeightAndRadius( 72, 8 ) );
		SetMaterialGroup( Game.Random.Int( 0, 3 ) );
		SetBodyGroup( 1, 0 );

		EnableHitboxes = true;
		Speed = Game.Random.Float( 100, 300 );
		Health = 100;
	}


}
