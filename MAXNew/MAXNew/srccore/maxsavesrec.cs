//maxsavesrec.cs from maxsavesrec.pas
//Max saves data

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using asys; //Dependance from .pas

namespace MAXNew.srccore
{
    public class maxsavesrec
    {
        //packed
        public class header156
        {
            public byte game_type;
            public char[] game_name = new char[30];
            public byte map_id_1;
            public ushort level_num;
            public char[, ] plr_name = new char[4, 30]; //not sure
            public byte[] plr_type = new byte [4];
            public byte alien_type;
            public uint creation_time;
            public byte cpuiq1;
            public ushort time_of_turn_1,time_of_end_turn_1;
            public byte turn_mode_1;
            public uint map_id_2;
            public uint time_of_turn_2;
            public uint time_of_end_turn_2;
            public uint sgold;
            public uint turn_mode_2;
            public uint type_of_end;
            public uint amt_to_end;
            public uint cpuiq2;
            public uint start_raw;
            public uint start_fuel;
            public uint start_gold;
            public uint start_alien; 
        }
        //############################################################################//
        public class header104
        {
            public byte game_type;
            public char[] game_name = new char[30];
            public byte map_id_1;
            public ushort level_num;
            public char[,] plr_name = new char[4, 30]; //not sure
            public byte[] plr_type = new byte[4];
            public byte alien_type;
            public byte[] unk104 = new byte[5];
            public uint creation_time;
            public byte cpuiq1;
            public ushort time_of_turn_1, time_of_end_turn_1;
            public byte turn_mode_1;
            public uint map_id_2;
            public uint time_of_turn_2;
            public uint time_of_end_turn_2;
            public uint sgold;
            public uint turn_mode_2;
            public uint type_of_end;
            public uint amt_to_end;
            public uint cpuiq2;
            public uint start_raw;
            public uint start_fuel;
            public uint start_gold;
            public uint start_alien;
        }
        //###########################################################################//
        public class resinfo
        {
            public uint now, unk, labs;
        }

        public class ob_word
        {
            public ushort ob;
            public bool full;
        }
        //############################################################################//
        public class player_info
        {
            public byte[] FF1 = new byte[40];
            public byte plr_type;
            public byte unk0;
            public byte clan;
            public resinfo[] research = new resinfo[8];
            public uint score;
            public ushort object_count;
            public byte[] unit_counters = new byte[93];   //"Connector x is done"
            public byte[] FF2 = new byte[12];
            public ushort[] scoregraph = new ushort[50];  //Scoore graph?//Each Point takes up two bytes. Thus, on 100 bytes, 50 Points can be stored for the graph. The Points seems to be signed values.
            public ushort selunit;
            public ushort zoom,xoff,yoff;          
            public byte[] buttons = new byte[11];
            public ushort factories_built, mines_built, buildings_built, units_built;
            public byte[] loses = new byte[186]; 
            public ushort goldused;
        }
        //pplayer_info=^player_info;
        public player_info pplayer_info;
        //############################################################################//
        public class mesgrec
        {
            public ushort len;
            public string msg;
        }

        public class pptrec
        {
            public sbyte x, y;
        }

        public class unk_1_rec
        {
            public ushort a, b, c;
        }
        //############################################################################//                    
        //Object 3
        public class post_updates_record
        {
            public byte[] val = new byte[14]; 
        }
        //ppost_updates_record=^post_updates_record;
        public post_updates_record ppost_updates_record;
        //############################################################################//
        //Object 4
        public class path_def_block
        {
            public ushort target_x, target_y, zero1;
            public ushort cnt;
            public pptrec[] path;
        }
        //ppath_def_block=^path_def_block;
        public path_def_block ppath_def_block;
        //############################################################################//
        //Object 5     //154b
        public class unit_def_record
        {
            public ushort unid;

            public byte unk_byte_1, unk_byte_2;

            public uint flags;
            //          Bit7 {0x80}	       Bit6 {0x40}	     Bit5 {0x20}	     Bit4 {0x10}	  Bit3 {0x08}	      Bit2 {0x04}	    Bit1 {0x02}	       Bit0 {0x01}
            //018	FLAGS	mobile_sea_unit	   mobile_air_unit	 missile_unit	    building	     connector_unit	   animated	       exploding	         ground_cover
            //019	FLAGS	-	                 upgradeable	     -	               -	            -	                -	              stationary	        mobile_land_unit
            //020	FLAGS	standalone	        selectable	      electronic_unit	 -	            constructor_unit	 fires_missiles	 has_firing_sprite	 hovering
            //021	FLAGS	-	                 -	               -	               -            	spinning_turret	  sentry_unit	    turret_sprite	     requires_slab

            public ushort x_graphic, y_graphic, x_pos, y_pos;

            //14
            public ushort custom_name_length;
            public string custom_name;

            //16
            public short shadow_center_x_off, shadow_center_y_off;
            public byte owner;
            public byte unit_number;
            public byte brightness;
            public byte rot;

            public byte vis_red, vis_green, vis_blue, vis_gray, vis_alien;
            public byte spotted_red, spotted_green, spotted_blue, spotted_gray, spotted_alien;
            public byte ubv5, velocity;  
            public byte state;  
            public byte is_stored;

            public uint udv1,udv2,udv3,udv4,udv5,udv6,udv7,udv8;
 
            public byte gun_rot;
            public byte ub2v2, ub2v3;

            public ushort total_images, image_base, turret_image_base, firing_image_base, connector_image_base;
 
            public byte base_sprite; //{rot, water, active,...}
 
            public byte uwv6b;
            public ushort anim_sprite_1;
            public ushort uwv8;  
 
            public byte orders, state_done, prior_orders, prior_state, ub2v8;
            public ushort target_x,target_y; 
 
            //100
            public byte turns_left_base;
            public byte mining_tot_sel, mining_res_sel, mining_ful_sel, mining_gld_sel, mining_res_avl, 
                mining_ful_avl,mining_gld_avl;
   
            public byte hitsnow, speednow, shotnow, shotmove;
            public ushort cargonow;
            public byte ammonow;   
  
            public byte targeting_mode,enter_mode,cursor;    
            //118 
            public byte recoil_delay, delayed_reaction, damaged_this_turn, research_topic;

            public byte[] unk_arr_4 = new byte[9];
            public byte repeat_build, bld_speed;

            //Objects
            public ob_word unk_obj_1;
            public ob_word unk_obj_2;
            public ob_word unk_obj_3;
            //140
            public ob_word pathobj;
            public ushort connectors;
            public ob_word object_used;
            public ob_word unk_obj_4;              
            public ob_word inside_obj;
            public ob_word unk_obj_5;
 
            public ushort is_build_n;
            public ushort[] build_unit_num;
        }
        //punit_def_record=^unit_def_record;
        public unit_def_record punit_def_record;
        //############################################################################//
        //Object 6
        public class unit_pars_record
        {
            public ushort cost, hits, armr, attk, speed, range, shot;
            public byte movnf;
            public ushort scan, store, ammo, area;
            public byte z31;
            public byte unk0, unk1, unk2, unk3;
        }
        //punit_pars_record=^unit_pars_record;
        public unit_pars_record punit_pars_record;
        //############################################################################//
        //Object list
        public class objlstrec
        {
            public ushort id, tp;
            public object info; 
        }
        //############################################################################//
        //############################################################################//
        //############################################################################//
        
        public readonly string[] btnames = new string[11] {"Range", "Scan", "Status", "Colors", "Hits", "Ammo", "Names", "2X", "TNT", "Grid", "Survey"};
        public readonly string[] clannames = new string[8] {"The Choosen", "Crimson Path", "Von Griffin", "Ayer's Hand", "Musashi", "Sacred Eights", "7 Knights", "Axis Inc."};
        public readonly string[] resrchnames = new string[8] {"Attack", "Shot", "Range", "Armor", "Hits", "Speed", "Scan", "Cost"};

        public readonly string[] def_maps = new string[24]
        {
            "Snow_1"  ,"Snow_2"  ,"Snow_3"  ,"Snow_4"  ,"Snow_5"  ,"Snow_6",
            "Crater_1","Crater_2","Crater_3","Crater_4","Crater_5","Crater_6",
            "Green_1" ,"Green_2" ,"Green_3" ,"Green_4" ,"Green_5" ,"Green_6",
            "Desert_1","Desert_2","Desert_3","Desert_4","Desert_5","Desert_6"
        };

        public readonly int[] x_buttons = new int[12] {10, 9, -1, 1, 0, 3, 4, 2, 5, -1, 6, -1};
        public readonly int[] x_clans = new int[8] {0, 1, 2, 3, 4, 5, 6, 7};
                        
        public readonly byte[, ] plr_color = new byte[4, 3] {{252, 0, 0}, {0, 252, 0}, {0, 0, 252}, {128, 128, 160}};

        public const UInt32 HD104=0x0046;
        public const UInt32 HD156=0x0045;

        public readonly string[, ] uninames = new string[93, 4] 
        {
            {"COMM_TOWER"      ,"Gold Refinery"   ,"gref"       ,"B2"},
            {"POWER_STN"       ,"Power Plant"     ,"Powerpl"    ,"B2"},
            {"POWER_GEN"       ,"Power Generator" ,"Powergen"   ,"B1"},
            {"BARRACKS"        ,"Barracks"        ,"barrak"     ,"B2"},
            {"SHIELD_GEN"      ,"Shield Generator",""           ,"B2"},
            {"RADAR"           ,"Radar"           ,"Radar"      ,"B1"},
            {"SMALL STORAGE"   ,"Material Store"  ,"Matstore"   ,"B1"},
            {"SMALL FUEL_TANK" ,"Fuel Store"      ,"Fuelstore"  ,"B1"},
            {"SMALL GOLD VAULT","Gold Store"      ,"Goldstore"  ,"B1"},
            {"DEPOT"           ,"Depot"           ,"Store"      ,"B2"},        
            {"HANGAR"          ,"Hangar"          ,"Hang"       ,"B2"},
            {"DOCK"            ,"Dock"            ,"Dock"       ,"B2"},
            {"CONNECTOR_4W"    ,"Connector"       ,"Conn"       ,"B1"},
            {"LARGE_RUBBLE"    ,"Big Rubble"      ,"Bigrubble"  ,"B2"},
            {"SMALL_RUBBLE"    ,"Small rubble"    ,"Smlrubble"  ,"B1"},
            {"LARGE_TAPE"      ,"Big Rope"        ,"Bigrope"    ,"B2"},
            {"SMALL_TAPE"      ,"Small Rope"      ,"Smlrope"    ,"B1"},
            {"LARGE_SLAB"      ,"Big Plate"       ,"Bigplate"   ,"B2"},
            {"SMALL_SLAB"      ,"Small Plate"     ,"Smlplate"   ,"B1"},
            {"LARGE_CONES"     ,"Big Cones"       ,"Bigcone"    ,"B2"},
            {"SMALL_CONES"     ,"Small Cones"     ,"Smlcone"    ,"B1"},
            {"ROAD"            ,"Road"            ,"Road"       ,"B1"},
            {"LANDING_PAD"     ,"Landing pad"     ,"landpad"    ,"B1"},
            {"SHIPYARD"        ,"Shipyard"        ,"Shipyard"   ,"B2"},
            {"LIGHT_UNIT_PLANT","Light Plant"     ,"Lightplant" ,"B2"},
            {"LAND_UNIT_PLANT" ,"Heavy Plant"     ,"Hvplant"    ,"B2"},    //25 //26
            {"SUPPORT_PLANT"   ,"Support Plant"   ,""           ,"B2"},
            {"AIR_UNIT_PLANT"  ,"Air Plant"       ,"Airplant"   ,"B2"},
            {"HABITAT"         ,"Habitat"         ,"Habitat"    ,"B2"},
            {"RESEARCH_CENTER" ,"Lab"             ,"research"   ,"B2"},    
            {"GREEN HOUSE"     ,"Ecosphere"       ,"Ecosphere"  ,"B2"},   
            {"REC CENTER"      ,"Recr Center"     ,""           ,"B2"},
            {"TRAINING HALL"   ,"Training Hall"   ,"pehplant"   ,"B2"},
            {"SEA RIG"         ,"Sea Platform"    ,"Plat"       ,"B1"},
            {"Gun Turret"      ,"Gun Turret"      ,"turret"     ,"B1"},
            {"ANTI_AIRCRAFT"   ,"AA Turret"       ,"Zenit"      ,"B1"},
            {"artillery turret","Artillery Turret","Arturret"   ,"B1"},
            {"Missile turret"  ,"Missile Turret"  ,"misturret"  ,"B1"},
            {"BLOCK"           ,"Block"           ,"Conblock"   ,"B1"},
            {"BRIDGE"          ,"Bridge"          ,"Bridge"     ,"B1"},
            {"MINING_STATION"  ,"Mining"          ,"Mining"     ,"B2"},    //40  //41
            {"LAND MINE"       ,"Land Mine"       ,"landmine"   ,"B1"},
            {"SEA MINE"        ,"Sea Mine"        ,"seamine"    ,"B1"},
            {"LAND EXPLOSION"  ,"Land Boom"       ,"-"          ,"A1"},
            {"AIR EXPLOSION"   ,"Air Boom"        ,"-"          ,"A1"},
            {"SEA EXPLOSION"   ,"Sea Boom"        ,"-"          ,"A1"},
            {"BUILDING EXPLO"  ,"Bld Boom"        ,"-"          ,"A2"},
            {"HIT EXPLOSION"   ,"Hit Boom"        ,"-"          ,"A1"},
            {"MASTER_UNIT"     ,"Master Unit"     ,"-"          ,"A1"},
            {"CONSTRUCTOR"     ,"Constructor"     ,"Constructor","U1"}, //49 //50   $32
            {"SCOUT"           ,"Scout"           ,"Scout"      ,"U1"},
            {"TANK"            ,"Tank"            ,"Tank"       ,"U1"},
            {"ASSUALT GUN"     ,"Assault Gun"     ,"Asgun"      ,"U1"},
            {"Rocket launcher" ,"Rocketter"       ,"Rocket"     ,"U1"},
            {"MISSLE_LAUNCHER" ,"Grad Launcher"   ,"Crawler"    ,"U1"},
            {"MOBILE AA"       ,"Mobile AA Gun"   ,"Aagunm"     ,"U1"},
            {"MINE_LAYER"      ,"Mine Layer"      ,"Miner"      ,"U1"},
            {"SURVEYOR"        ,"Surveyor"        ,"Surveyor"   ,"U1"},     //58   $3A
            {"SCANNER"         ,"Scanner"         ,"Scanner"    ,"U1"},
            {"SUPPLY TRUCK"    ,"Material Truck"  ,"Truck"      ,"U1"},
            {"GOLD TRUCK"      ,"Gold Truck"      ,"Gtruck"     ,"U1"},
            {"ENGINEER"        ,"Engineer"        ,"Engineer"   ,"U1"},
            {"BULLDOZER"       ,"Bulldozer"       ,"Dozer"      ,"U1"},
            {"REPAIR"          ,"Repair Unit"     ,"Repair"     ,"U1"},
            {"FUEL TRUCK"      ,"Fuel Truck"      ,"Fueltruck"  ,"U1"},
            {"COLONIST TRANS"  ,"Personnel Car"   ,"pcan"       ,"U1"},
            {"COMMANDO"        ,"Infiltrator"     ,"Infil"      ,"U1"},
            {"INFANTRY"        ,"Infantry"        ,"infantry"   ,"U1"},
            {"AA BOAT"         ,"Escort"          ,"Escort"     ,"U1"},
            {"CORVETTE"        ,"Corvette"        ,"Corvette"   ,"U1"},
            {"GUNBOAT"         ,"Gunboat"         ,"Gunboat"    ,"U1"},
            {"SUBMARINE"       ,"Submarine"       ,"sub"        ,"U1"},
            {"SEA_TRANSPORT"   ,"Sea Transport"   ,"Seatrans"   ,"U1"},
            {"MISSLE_BOAT"     ,"Rocket Boat"     ,"Rokcr"      ,"U1"},
            {"SEA MINE LAYER"  ,"Sea Mine Layer"  ,"seaminelay" ,"U1"},
            {"CARGO SHIP"      ,"Cargo Ship"      ,"Seacargo"   ,"U1"},
            {"FIGHTER"         ,"Interceptor"     ,"Inter"      ,"U1"},
            {"BOMBER"          ,"Bomber"          ,"Bomber"     ,"U1"},
            {"AIR_TRANSPORT"   ,"Air Transport"   ,"Airtrans"   ,"U1"},
            {"AWAC"            ,"AWAC"            ,"Awac"       ,"U1"},
            {"ALIEN GUN BOAT"  ,"Alien Gunboat"   ,"juger"      ,"U1"},
            {"ALIEN TANK"      ,"Alien Tank"      ,"alntank"    ,"U1"},
            {"ALIEN ASSGUN"    ,"Alien Assgun"    ,"alnasgun"   ,"U1"},
            {"ALIEN ATTPLANE"  ,"Alien Bomber"    ,"alnplane"   ,"U1"},
            {"ROCKET"          ,"Rocket"          ,"-"          ,"A1"},
            {"TORPEDO"         ,"Torpedo"         ,"-"          ,"A1"},
            {"ALIEN MISSLE"    ,"Alien Missile"   ,"-"          ,"A1"},
            {"ALIEN TANK PBALL","Alien Tank PBall","-"          ,"A1"},
            {"ALIEN ART PBALL" ,"Alien Art PBall" ,"-"          ,"A1"},
            {"SMOKE_TRAIL"     ,"Smoke Trail"     ,"-"          ,"A1"},
            {"BUBBLE_TRAIL"    ,"Bubble Trail"    ,"-"          ,"A1"},
            {"HARVESTER"       ,"Harvester"       ,"-"          ,"A1"},
            {"WALDO"           ,"Waldo"           ,"-"          ,"A1"}
        };
        //############################################################################//
        public class saveorec
        {
            public ushort id;
            public header104 head;
 
            public byte[] pasmap = new byte[12544];
            public byte[] resmap = new byte[25088];

            public player_info[] pi = new player_info[5];  

            public byte doing_turn;   //Who is actually taking it's turn. If Player 1 is active, the value is 0.
            public byte turn_status;  //Is the Turn already started?
            public uint cur_turn;
            public ushort game_state;
            //0-7	Exit to main menu
            //8	Player takes it's turn
            //9	Next player comes
            //10	Game hangs
            //11+	Exit to main menu
            public ushort victory_state;

            public uint anim_effects;      //0 = OFF ; 1 = ON (Animate effects)
            public uint click_scroll;      //0 = OFF ; 1 = ON (Click to scroll)
            public uint scroll_speed;      //4 - 128 (Scroll speed); >4 default speed -> 16; <128 max speed;
            public uint double_steps;      //0 = OFF ; 1 = ON (Double unit steps)
            public uint track_selected;    //0 = OFF ; 1 = ON (Track selected unit)
            public uint auto_select;       //0 = OFF ; 1 = ON (Auto select unit)
            public uint enemy_halt;        //0 = OFF ; 1 = ON (Auto select unit)

            public objlstrec[] objlst ;
            public int lob; 
               
            public ushort[] update_cnt, plr_gold = new ushort[4]; 
            public ob_word[, ] plr_obs_a = new ob_word[4, 93*2];
            public ob_word[][] plr_obs_b = new ob_word[4][];
            public ushort unsel_count, moving_count, bldg_count, air_count;
            public ob_word[, ] unsel_obs, moving_obs, bldg_obs, air_obs;
                  
            //plr_start:array[0..3]of integer; // Commented at .pas
            public int unitcnt, mg_unitcnt, unitstart;
            public int plr_count;
 
            public byte[] postunits_unk = new byte[8];

            public unk_1_rec[] unk_post_1;

            public byte[, ] scan_map = new byte[4, 12544];
            public byte[, ] corvett_map = new byte[4, 12544];
            public byte[, ] infantry_map = new byte[4, 12544];

            public ushort[] msg_cnt = new ushort[4];
            public mesgrec[][] mesgs = new mesgrec[4][];

            //Score graph record
            //Messages
            //Etc?
 
            public object restof; //Donno wut todo
            public uint restsize;               
        }           
    }
}
