using System.Collections.Generic;
using UnityEngine;

namespace TheOtherRoles.Utilities;

#nullable enable
public class MapData
{
     public static readonly List<Vector3> SkeldSpawnPosition =
     [
         new(-2.2f, 2.2f, 0.0f), //cafeteria. botton. top left.
         new(0.7f, 2.2f, 0.0f), //caffeteria. button. top right.
         new(-2.2f, -0.2f, 0.0f), //caffeteria. button. bottom left.
         new(0.7f, -0.2f, 0.0f), //caffeteria. button. bottom right.
         new(10.0f, 3.0f, 0.0f), //weapons top
         new(9.0f, 1.0f, 0.0f), //weapons bottom
         new(6.5f, -3.5f, 0.0f), //O2
         new(11.5f, -3.5f, 0.0f), //O2-nav hall
         new(17.0f, -3.5f, 0.0f), //navigation top
         new(18.2f, -5.7f, 0.0f), //navigation bottom
         new(11.5f, -6.5f, 0.0f), //nav-shields top
         new(9.5f, -8.5f, 0.0f), //nav-shields bottom
         new(9.2f, -12.2f, 0.0f), //shields top
         new(8.0f, -14.3f, 0.0f), //shields bottom
         new(2.5f, -16f, 0.0f), //coms left
         new(4.2f, -16.4f, 0.0f), //coms middle
         new(5.5f, -16f, 0.0f), //coms right
         new(-1.5f, -10.0f, 0.0f), //storage top
         new(-1.5f, -15.5f, 0.0f), //storage bottom
         new(-4.5f, -12.5f, 0.0f), //storrage left
         new(0.3f, -12.5f, 0.0f), //storrage right
         new(4.5f, -7.5f, 0.0f), //admin top
         new(4.5f, -9.5f, 0.0f), //admin bottom
         new(-9.0f, -8.0f, 0.0f), //elec top left
         new(-6.0f, -8.0f, 0.0f), //elec top right
         new(-8.0f, -11.0f, 0.0f), //elec bottom
         new(-12.0f, -13.0f, 0.0f), //elec-lower hall
         new(-17f, -10f, 0.0f), //lower engine top
         new(-17.0f, -13.0f, 0.0f), //lower engine bottom
         new(-21.5f, -3.0f, 0.0f), //reactor top
         new(-21.5f, -8.0f, 0.0f), //reactor bottom
         new(-13.0f, -3.0f, 0.0f), //security top
         new(-12.6f, -5.6f, 0.0f), // security bottom
         new(-17.0f, 2.5f, 0.0f), //upper engibe top
         new(-17.0f, -1.0f, 0.0f), //upper engine bottom
         new(-10.5f, 1.0f, 0.0f), //upper-mad hall
         new(-10.5f, -2.0f, 0.0f), //medbay top
         new(-6.5f, -4.5f, 0.0f)
     ];

     public static readonly List<Vector3> MiraSpawnPosition =
     [
         new(-4.5f, 3.5f, 0.0f), //launchpad top
         new(-4.5f, -1.4f, 0.0f), //launchpad bottom
         new(8.5f, -1f, 0.0f), //launchpad- med hall
         new(14f, -1.5f, 0.0f), //medbay
         new(16.5f, 3f, 0.0f), // comms
         new(10f, 5f, 0.0f), //lockers
         new(6f, 1.5f, 0.0f), //locker room
         new(2.5f, 13.6f, 0.0f), //reactor
         new(6f, 12f, 0.0f), //reactor middle
         new(9.5f, 13f, 0.0f), //lab
         new(15f, 9f, 0.0f), //bottom left cross
         new(17.9f, 11.5f, 0.0f), //middle cross
         new(14f, 17.3f, 0.0f), //office
         new(19.5f, 21f, 0.0f), //admin
         new(14f, 24f, 0.0f), //greenhouse left
         new(22f, 24f, 0.0f), //greenhouse right
         new(21f, 8.5f, 0.0f), //bottom right cross
         new(28f, 3f, 0.0f), //caf right
         new(22f, 3f, 0.0f), //caf left
         new(19f, 4f, 0.0f), //storage
         new(22f, -2f, 0.0f)
     ];

     public static readonly List<Vector3> PolusSpawnPosition =
     [
         new(16.6f, -1f, 0.0f), //dropship top
         new(16.6f, -5f, 0.0f), //dropship bottom
         new(20f, -9f, 0.0f), //above storrage
         new(22f, -7f, 0.0f), //right fuel
         new(25.5f, -6.9f, 0.0f), //drill
         new(29f, -9.5f, 0.0f), //lab lockers
         new(29.5f, -8f, 0.0f), //lab weather notes
         new(35f, -7.6f, 0.0f), //lab table
         new(40.4f, -8f, 0.0f), //lab scan
         new(33f, -10f, 0.0f), //lab toilet
         new(39f, -15f, 0.0f), //specimen hall top
         new(36.5f, -19.5f, 0.0f), //specimen top
         new(36.5f, -21f, 0.0f), //specimen bottom
         new(28f, -21f, 0.0f), //specimen hall bottom
         new(24f, -20.5f, 0.0f), //admin tv
         new(22f, -25f, 0.0f), //admin books
         new(16.6f, -17.5f, 0.0f), //office coffe
         new(22.5f, -16.5f, 0.0f), //office projector
         new(24f, -17f, 0.0f), //office figure
         new(27f, -16.5f, 0.0f), //office lifelines
         new(32.7f, -15.7f, 0.0f), //lavapool
         new(31.5f, -12f, 0.0f), //snowmad below lab
         new(10f, -14f, 0.0f), //below storrage
         new(21.5f, -12.5f, 0.0f), //storrage vent
         new(19f, -11f, 0.0f), //storrage toolrack
         new(12f, -7f, 0.0f), //left fuel
         new(5f, -7.5f, 0.0f), //above elec
         new(10f, -12f, 0.0f), //elec fence
         new(9f, -9f, 0.0f), //elec lockers
         new(5f, -9f, 0.0f), //elec window
         new(4f, -11.2f, 0.0f), //elec tapes
         new(5.5f, -16f, 0.0f), //elec-O2 hall
         new(1f, -17.5f, 0.0f), //O2 tree hayball
         new(3f, -21f, 0.0f), //O2 middle
         new(2f, -19f, 0.0f), //O2 gas
         new(1f, -24f, 0.0f), //O2 water
         new(7f, -24f, 0.0f), //under O2
         new(9f, -20f, 0.0f), //right outside of O2
         new(7f, -15.8f, 0.0f), //snowman under elec
         new(11f, -17f, 0.0f), //comms table
         new(12.7f, -15.5f, 0.0f), //coms antenna pult
         new(13f, -24.5f, 0.0f), //weapons window
         new(15f, -17f, 0.0f), //between coms-office
         new(17.5f, -25.7f, 0.0f)
     ];

     public static readonly List<Vector3> DleksSpawnPosition = // No Dleks
     [
         new(2.2f, 2.2f, 0.0f), //cafeteria. botton. top left.
         new(-0.7f, 2.2f, 0.0f), //caffeteria. button. top right.
         new(2.2f, -0.2f, 0.0f), //caffeteria. button. bottom left.
         new(-0.7f, -0.2f, 0.0f), //caffeteria. button. bottom right.
         new(-10.0f, 3.0f, 0.0f), //weapons top
         new(-9.0f, 1.0f, 0.0f), //weapons bottom
         new(-6.5f, -3.5f, 0.0f), //O2
         new(-11.5f, -3.5f, 0.0f), //O2-nav hall
         new(-17.0f, -3.5f, 0.0f), //navigation top
         new(-18.2f, -5.7f, 0.0f), //navigation bottom
         new(-11.5f, -6.5f, 0.0f), //nav-shields top
         new(-9.5f, -8.5f, 0.0f), //nav-shields bottom
         new(-9.2f, -12.2f, 0.0f), //shields top
         new(-8.0f, -14.3f, 0.0f), //shields bottom
         new(-2.5f, -16f, 0.0f), //coms left
         new(-4.2f, -16.4f, 0.0f), //coms middle
         new(-5.5f, -16f, 0.0f), //coms right
         new(1.5f, -10.0f, 0.0f), //storage top
         new(1.5f, -15.5f, 0.0f), //storage bottom
         new(4.5f, -12.5f, 0.0f), //storrage left
         new(-0.3f, -12.5f, 0.0f), //storrage right
         new(-4.5f, -7.5f, 0.0f), //admin top
         new(-4.5f, -9.5f, 0.0f), //admin bottom
         new(9.0f, -8.0f, 0.0f), //elec top left
         new(6.0f, -8.0f, 0.0f), //elec top right
         new(8.0f, -11.0f, 0.0f), //elec bottom
         new(12.0f, -13.0f, 0.0f), //elec-lower hall
         new(17f, -10f, 0.0f), //lower engine top
         new(17.0f, -13.0f, 0.0f), //lower engine bottom
         new(21.5f, -3.0f, 0.0f), //reactor top
         new(21.5f, -8.0f, 0.0f), //reactor bottom
         new(13.0f, -3.0f, 0.0f), //security top
         new(12.6f, -5.6f, 0.0f), // security bottom
         new(17.0f, 2.5f, 0.0f), //upper engibe top
         new(17.0f, -1.0f, 0.0f), //upper engine bottom
         new(10.5f, 1.0f, 0.0f), //upper-mad hall
         new(10.5f, -2.0f, 0.0f), //medbay top
         new(6.5f, -4.5f, 0.0f)
     ];
     
     public static readonly List<Vector3> AirshipSpawnPosition = 
     [
         // No Spawn Position for airships
     ];
     
     public static readonly List<Vector3> FungleSpawnPosition =
     [
         new(-10.0842f, 13.0026f, 0.013f),
         new(0.9815f, 6.7968f, 0.0068f),
         new(22.5621f, 3.2779f, 0.0033f),
         new(-1.8699f, -1.3406f, -0.0013f),
         new(12.0036f, 2.6763f, 0.0027f),
         new(21.705f, -7.8691f, -0.0079f),
         new(1.4485f, -1.6105f, -0.0016f),
         new(-4.0766f, -8.7178f, -0.0087f),
         new(2.9486f, 1.1347f, 0.0011f),
         new(-4.2181f, -8.6795f, -0.0087f),
         new(19.5553f, -12.5014f, -0.0125f),
         new(15.2497f, -16.5009f, -0.0165f),
         new(-22.7174f, -7.0523f, 0.0071f),
         new(-16.5819f, -2.1575f, 0.0022f),
         new(9.399f, -9.7127f, -0.0097f),
         new(7.3723f, 1.7373f, 0.0017f),
         new(22.0777f, -7.9315f, -0.0079f),
         new(-15.3916f, -9.3659f, -0.0094f),
         new(-16.1207f, -0.1746f, -0.0002f),
         new(-23.1353f, -7.2472f, -0.0072f),
         new(-20.0692f, -2.6245f, -0.0026f),
         new(-4.2181f, -8.6795f, -0.0087f),
         new(-9.9285f, 12.9848f, 0.013f),
         new(-8.3475f, 1.6215f, 0.0016f),
         new(-17.7614f, 6.9115f, 0.0069f),
         new(-0.5743f, -4.7235f, -0.0047f),
         new(-20.8897f, 2.7606f, 0.002f)
     ];


     private static List<Vector3>? VentSpawnPositions;
     
     public static List<Vector3> FindVentSpawnPositions()
     {
         if (VentSpawnPositions != null) return VentSpawnPositions;
         
         var poss = new List<Vector3>();
         foreach (var vent in DestroyableSingleton<ShipStatus>.Instance.AllVents)
         {
             var Transform = vent.transform;
             var position = Transform.position;
             poss.Add(new Vector3(position.x, position.y + 0.2f, position.z - 50));
         }

         VentSpawnPositions = poss;
         return poss;
     }
}