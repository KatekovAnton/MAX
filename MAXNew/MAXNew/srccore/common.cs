//common.cs from common.pas

//Defining for convinient programming 
#define ape3
#define downloading

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MAXNew.srccore
{
    public class common
    {
        const int MAX_PLR = 20;

        #if (ape3)
            public const string mgrootdir_loc = "/mga";
        #else
            public const string mgrootdir_loc = "/mgaruntime";
        #endif 

        public const string mgrootdir = mgrootdir_loc + "/";
        public const uint MGSAVE_BASE_SGN=0x584E474D;
        public const uint MGSAVE_REST_SGN=0x5847534D;
        public const uint MGSRV_SGN=0x5358474D;
        public const string def_uniset="original";

        #if downloading        
            public const bool VFS_GLOBAL_DOMAIN=true;       //Allow other thread to access VFS
        #else
            public const bool VFS_GLOBAL_DOMAIN=false;
        #endif

        public readonly string[] clannames = new string[8] {"The Choosen", "Crimson Path", "Von Griffin", 
            "Ayer's Hand", "Musashi", "Sacred Eights", "7 Knights", "Axis Inc."};

        //############################################################################//
        //Research
        public const int RS_COUNT=8;
        public readonly string[] res_names = new string[RS_COUNT] {"Attack", "Shots", "Range", "Armor", "Hits",
            "Speed", "Scan", "Cost"};
        //############################################################################//
        //Upgrades
        public readonly int[] def_ut_factors = new int[10] {16, 16, 8, 32, 32, 16, 8, 8, 32, 8};
        public const int max_upgrade_price = 1000;
        public const int research_increase = 10;   
  
        public const int ut_attk  = 0;  
        public const int ut_shot  = 1;  
        public const int ut_range = 2;  
        public const int ut_armor = 3;  
        public const int ut_hits  = 4; 
        public const int ut_speed = 5;  
        public const int ut_scan  = 6;
        public const int ut_cost  = 7;
        public const int ut_ammo  = 8;  
        public const int ut_fuel  = 9; 

        //############################################################################//
        //States
        public const int ST_THEMENU = 0;        //Main menus
        public const int ST_THEGAME = 1;        //The game as played
        public const int ST_INSGAME = 2;        //Between turns
        public const int ST_SETGAME = 3;        //Pre-game setup
        //############################################################################//
        //Game menus
        public const int MG_NOMENU      = 0;
        public const int MG_DEBUG       = 1;
        public const int MG_BUILD       = 2;
        public const int MG_XFER        = 3;
        public const int MG_DEPOT       = 4;
        public const int MG_BOOM        = 5;
        public const int MG_UPGRLAB     = 6;
        public const int MG_MINE        = 7;
        public const int MG_UNITINFO    = 8;   
        public const int MG_ESCSAVE     = 9; 
        public const int MG_REPORT      = 10;
        public const int MG_UNIT_RENAME = 11;
        public const int MG_CLAN_INFO   = 12;
        public const int MG_CUSTOM_CLRS = 13;
        public const int MG_DIPLOMACY   = 14;
        //Shared menus
        public const int MG_LOADSAVE    = 15;
        public const int MG_UPGRMONEY   = 16;
        public const int MG_MENUCOUNT   = MG_UPGRMONEY;
        //############################################################################//
        //Events
        public const int evt_calcmenu_03      = 1;
        public const int evt_enter_build_menu = 2;
        public const int evt_exter_xfer_menu  = 3;
        public const int evt_enter_depot_menu = 4;
        public const int evt_calcmenu_r       = 5;
        public const int evt_domenu_r         = 6;
        public const int evt_domenu_14        = 7;
        public const int evt_do_xfer_menu     = 8; 
        public const int end_turn_request     = 9;

        public const int evt_set_begin_mat = 10;
        public const int evt_begins_buy    = 11;
        public const int evt_begins_sell   = 12;

        public const int evt_build_building      = 13;
        public const int evt_build_building_path = 14;
        public const int evt_add_build_unit_cur  = 15;
        public const int evt_rem_build_unit_cur  = 16;
        public const int evt_building_build_ok   = 17;

        public const int evt_do_buys_menu                 = 18;   
        public const int evt_set_cur_build_unit_speed     = 19;  
        public const int evt_sel_unit_on_build_queue      = 20;
        public const int evt_build_change_sel_unit_speed  = 21;
        public const int evt_build_sel_unit_on_list       = 22;
        public const int evt_build_add_sel_unit_to_queues = 23;

        public const int evt_update_och_build_menu = 24;

        public const int choose_clan_curplr    = 101;
        public const int evt_set_game_menu     = 102;
        public const int evt_stop_motion       = 103;
        public const int evt_stop_action       = 104;
        public const int evt_begins_select_set = 105;
        public const int evt_init_mine_menu    = 106;
        public const int evt_dbg_place_unit    = 107;
        public const int evt_cursor_calc       = 108;  
        public const int evt_buys_menu_accept  = 109; 
        public const int evt_buys_menu_cancel  = 110; 
        public const int evt_select_unit       = 111;
        public const int evt_unit_done         = 112;
        public const int evt_upgrade_unit      = 113;
        public const int evt_reload_unit       = 114;
        public const int evt_repair_unit       = 115;
        public const int evt_refuel_unit       = 116;
        public const int evt_change_research   = 117;
        public const int evt_get_next_save     = 118;
        public const int evt_upload_save       = 119; 
        public const int evt_get_this_save     = 120;
        public const int evt_update_server     = 121;
        public const int evt_reload_saves      = 122;
        public const int evt_update_research   = 123;
        public const int evt_me_surrender      = 124;
        //############################################################################//
        public const int clan_unitbonus = 2;
        //############################################################################// 
        public const int num_nextplayer = 0;
        //############################################################################// 
        public const int tool_none   = 0;
        public const int tool_reload = 1;
        public const int tool_repair = 2;
        public const int tool_refuel = 3;
        //############################################################################//       
        public const int stsk_none  = 0;
        public const int stsk_load  = 1;
        public const int stsk_shoot = 2;
        public const int stsk_enter = 3;  
        public const int stsk_shoot_place = 4;  
        public const int stsk_refuel = 5;  
        public const int stsk_reload = 6;  
        public const int stsk_repair = 7;  
        //############################################################################//
        public const int ml_names = 0;
        public const int ml_dirs  = 1;
        public const int ml_cfgs  = 2;
        public const int ml_desc  = 3;
        //############################################################################//
        public const int MAX_BEGINS = 100;  //Initial purchases count
        public const int MAX_STATS  = 40;    //Statistical elements
        public const int MAX_PRESEL = 10;   //Stored unit selections
        public const int MAX_CAMPOS = 4;    //Stored camera positions
        //############################################################################//
        //Test type  
        public const int TPT_bridge_or_plat_here = 1;  
        public const int TPT_fire_pos = 2;
        //############################################################################//
        //RMNU functions (ochevidno)
        public const int RMNU_BILD      = 1;
        public const int RMNU_STPB      = 2;
        public const int RMNU_STPA      = 3;
        public const int RMNU_STRT      = 4;
        public const int RMNU_BLOW      = 5;
        public const int RMNU_ACTV      = 6;
        public const int RMNU_ENTR      = 7;
        public const int RMNU_LOAD      = 8;
        public const int RMNU_DONE      = 9;
        public const int RMNU_XFER      = 10;
        public const int RMNU_REFL      = 11;
        public const int RMNU_ATTK      = 12;
        public const int RMNU_DOZE      = 13;
        public const int RMNU_PMIN      = 14;
        public const int RMNU_REPR      = 15;
        public const int RMNU_RELD      = 16;
        public const int RMNU_AUTO      = 17;
        public const int RMNU_RESC      = 18;
        public const int RMNU_ALLC      = 19;
        public const int RMNU_UPGR      = 20;  
        public const int RMNU_GMIN      = 21;
        public const int RMNU_SENT      = 22;
        public const int RMNU_STEAL     = 23;
        public const int RMNU_DISABLE   = 24;
        public const int RMNU_UPDATE    = 25;
        public const int RMNU_UPDATEALL = 26;
        public const int RMNU_MOVE      = 27;
        //############################################################################//
        public const int a_building        = 0;  
        public const int a_bld_on_plate    = 1;   
        public const int a_always_active   = 2;
        public const int a_half_selectable = 3;
        public const int a_unselectable    = 4;
        public const int a_stealth         = 5;
        public const int a_see_stealth     = 6;
        public const int a_mining          = 7;
        public const int a_human           = 8;
        public const int a_connector       = 9;
        public const int a_can_build_on    = 10;
        public const int a_bridge          = 11;
        public const int a_road            = 12;
        public const int a_passes_res      = 13;
        public const int a_cleaner         = 14;
        public const int a_repair          = 15;
        public const int a_infiltrator     = 16;
        public const int a_bomb            = 17;
        public const int a_bomb_placer     = 18;
        public const int a_self_repair     = 19;
        public const int a_ecosphere       = 20;
        public const int a_reloader        = 21;
        public const int a_research        = 22;
        public const int a_landing_pad     = 23;
        public const int a_surveyor        = 24;
        public const int a_disableable     = 25;
        public const int a_upgrader        = 26;
        public const int a_begin_buyable   = 27;
        public const int a_animation       = 28; 
        public const int a_underwater      = 29;
        public const int a_see_underwater  = 30;
        public const int a_see_mines       = 31;
  
        public const int a_effectively_bridge  = 1000;
        public const int a_solid_building      = 1001;
        public const int a_can_be_fired_upon   = 1002;
        public const int a_ours                = 1003;
        public const int a_our_builder_working = 1004;
        public const int a_overbuild_disabled  = 1005;
        public const int a_autofireable        = 1006;
        public const int a_minor               = 1007;
        public const int a_positive_fuel       = 1008;
        public const int a_can_fire_now        = 1009;
        public const int a_would_autofire      = 1010;
        public const int a_was_detected        = 1011;
        public const int a_survives_overblast  = 1012;
        public const int a_bor                 = 1013;
        public const int a_leaves_decay        = 1014;  
        public const int a_can_fire            = 1015;
        public const int a_landed              = 1016;
        public const int a_disabled            = 1017;
        public const int a_sentry_or_not_bomb  = 1018;
        public const int a_stealth_or_underw   = 1019;
        public const int a_exclude_from_report = 1020;
        public const int a_stealthed           = 1021;
        public const int a_build_not_building  = 1022;
        public const int a_upgradable          = 1023;
        public const int a_run_on_completion   = 1024;
        public const int a_can_start_moving    = 1025;
        public const int a_would_fire          = 1026;
        //############################################################################// 
        public const int pt_landonly   = 0;       
        public const int pt_landcoast  = 1;       
        public const int pt_landwater  = 2;       
        public const int pt_watercoast = 3;       
        public const int pt_wateronly  = 4;       
        public const int pt_air        = 5;  
        //############################################################################//
        public const int P_INVALID  = 255;
        public const int P_LAND     = 0;
        public const int P_WATER    = 1;
        public const int P_COAST    = 2;
        public const int P_OBSTACLE = 3;
        //############################################################################//
        public const int FT_NONE             = 0;
        public const int FT_LAND_WATER_COAST = 1;
        public const int FT_WATER_COAST      = 2;
        public const int FT_AIR              = 3;
        public const int FT_ALL              = 4;     
        //############################################################################//
        public const int WT_NONE        = 0;
        public const int WT_GUN         = 1;  
        public const int WT_CASSETTE    = 2;  
        public const int WT_ROCKET      = 3;  
        public const int WT_AA          = 4;  
        public const int WT_TORPEDO     = 5;  
        public const int WT_ALIEN       = 6;  
        public const int WT_INFILTRATOR = 7;  
        public const int WT_BOMB        = 8;  
        //############################################################################//
        //Resource levels      
        public const int R_RICH   = 2;
        public const int R_MEDIUM = 1;
        public const int R_POOR   = 0;
        //############################################################################//
        //Infiltrator commands
        public const int IC_DISABLE = 0;
        public const int IC_STEAL   = 1;
        //############################################################################//
        public const int TP_HUMAN = 1;
        public const int TP_AI    = 2;          
        //############################################################################//
        //Scan Map levels
        public const int SL_NORMAL     = 0;
        public const int SL_UNDERWATER = 1;
        public const int SL_STEALTH    = 2;
        public const int SL_COUNT      = SL_STEALTH + 1;       
        //############################################################################//
        public const int CA_ANY_UNIT   = 1;
        public const int CA_ENEMY_UNIT = 2;
        public const int CA_PLANE      = 3;
        public const int CA_SMALLPLAT  = 4;
        public const int CA_BOMB       = 5;
        public const int CA_BRIDGE     = 6;
        public const int CA_ROAD       = 7;
        public const int CA_RUBBLE     = 8;
        public const int CA_BIGPLAT    = 9;         
        //############################################################################//
        public const int RES_NONE  = 0;
        public const int RES_MAT   = 1;
        public const int RES_FUEL  = 2;
        public const int RES_GOLD  = 3;
        public const int RES_POW   = 4;
        public const int RES_HUMAN = 5;

        //That hurts... But no better idea
        public const int RES_MINING_MIN = 1; //RES_MAT
        public const int RES_MINING_MAX = 3; //RES_GOLD
        public const int RES_MIN        = 1; //RES_MAT
        public const int RES_MAX        = 5; //RES_HUMAN
        //Placing a numeration from "zero"
        public readonly string[] res_ids = new string[RES_MAX] {"materials", "fuels", "golds", "powers", "mans"};
        //############################################################################//
        public const int ae_setup      = 0;
        public const int ae_begin_turn = 1;
        public const int ae_loop       = 2;
        //############################################################################//
        //Frame buttons
        public const int fb_survey     = 1;
        public const int fb_grid       = 2;
        public const int fb_speedrange = 3;
        public const int fb_scan       = 4;
        public const int fb_range      = 5;
        public const int fb_colors     = 6;
        public const int fb_hits       = 7;
        public const int fb_status     = 8;
        public const int fb_ammo       = 9;
        public const int fb_fuel       = 10;
        public const int fb_names      = 11;
        public const int fb_build      = 12;
        public const int fb_count      = fb_build;
        //############################################################################//
        //Log messages types
        public const int lmt_endturn            = 1;
        public const int lmt_build_completed    = 2;
        public const int lmt_research_completed = 3;
        public const int lmt_no_resources       = 4;
        public const int lmt_unit_under_attack  = 5;
        public const int lmt_unit_disabled      = 6;
        public const int lmt_unit_stolen        = 7;
        public const int lmt_enemy_unit_spoted  = 8;
        public const int lmt_enemy_unit_hiden   = 9;
        public const int lmt_enemy_unit_moved   = 10;
        public const int lmt_aircrash           = 11;
        public const int lmt_player_lost        = 12;
        public const int lmt_unit_destroyed     = 13;
        //############################################################################//
        //Pathfinding
        //{$ifndef wince}packed{$endif}
        public class prec
        {
            public Int16 px;
            public Int16 py;
            public Single pval, rpval;
            public byte dir;
        }
        public prec[] pathtyp;
        //############################################################################//
        //{$ifndef wince}packed{$endif}
        public class buildrec
        {
            public string typ;
            public int typ_db;
            public int x, y, sz;
            public bool rept, reverse;

            public int left_turns, left_to_build, left_mat, cur_speed, cur_use, 
                cur_take, given_speed;
            //Using baze instead of base because it reserved with syntax
            public int baze, tape, cones;
        }
        //pbuildrec=^buildrec;
        public buildrec pbuildrec;
        //############################################################################//
        //{$ifndef wince}packed{$endif}
        public class trktyp
        {
            public Int16 x, y, d, dx, dy;
            public Single t;
        }
        public trktyp[] atrktyp;
        //patrktyp=^atrktyp;
        public trktyp[] patrktyp;
        //############################################################################//
        public class prodrec
        {
            //Placing a numeration from "zero"
            public Int16[] num, use, now, pro, dbt = new Int16[RES_MAX];
            public Int16 rgoluse, rgolpro;
            public Int16 scorpro;
            //Placing a numeration from "zero"
            public Int16[] mining = new Int16[RES_MINING_MAX];
            //Placing a numeration from "zero"
            public Int16[] next_use = new Int16[RES_MAX];
        }
        //pprodrec=^prodrec;
        public prodrec pprodrec;
        //############################################################################//
        //{$ifndef wince}packed{$endif}
        public class statrec
        {
            public Int16 speed, hits, armr, attk, shoot, fuel, range, scan, cost, ammo, 
                area, mat_turn;
        }
        //pstatrec=^statrec;
        public statrec pstatrec;
        //############################################################################//
        //The unit type
        //{$ifndef wince}packed{$endif}
        public class typunits
        {
            public bool used;
            public string typ, name;                           //Type and name
            public Int16 dbn, cln, nm, mk;                     //DB num, Clan num, number of same model, model
            public int num;                                    //Index

            public int grp;                                    //Graphics pointer for client

            public byte ptyp, level, siz, cur_siz;             //Passage type, level, size, current size
 
            //Position
            public Int16 alt, own, x, y;                       //Altitude, owner, x,y position
            public Int16 prior_x, prior_y;    
            public byte rot, grot;                             //Orientation, gun orientation
            public byte ast;                                   //water-air kachania   
            public double anibasdt;
            public double aw_tim; 

            //Motion
            public Int16 xt, yt, xnt, ynt;                     //Target, next cell target
            public int mox, moy, dmx, dmy, mvel;
            public float vel;                                  //Speed
            public prec[] path;                                //Path //ReDo from pathtyp path
            public int pstep, plen;                            //Step and length of the path

            public statrec cur, bas;                           //Stats - current, basic
            public prodrec prod, prod_temp;                    //Resources - current, computational
            public int domain;
            public Int16 researching;                          //Reseacrh topic
            public bool was_fired_on;                          //Was fired on last turn
      
            //State
            public bool is_unselectable, is_sentry, is_moving, is_movingble, is_moving_now, isact, strtmov, 
                stpmov, stlmov, isboom, isstd, isauto, isclrg, stored, isbuild, isbuildfin, isinlnd, 
                isbmbpl, isbmbrm;    
            public bool[] in_lock = new bool[MAX_PLR];

            //State infos and etc
            public int clrturns, clr_unit, clr_tape;
            public Int16 clrval;  
            public int stored_in, strcnt, disabled_for;
 
            //Builds       
            public buildrec[] builds = new buildrec[21];   
            public int builds_cnt;
            public int reserve;                                //Materials Reserve

            //Stopping event
            public int stop_task, stop_target, stop_param;
            public bool stop_task_pending;

            //Firing
            public bool isfiring,firdr;
            public Int16 firingstg; 
            public double blastf, firdrf;
            public Vector2 firing_at;
            public bool triggered_auto_fire, afireip;

            //Storage
            public Int16 store_lnd, store_wtr, store_air, store_hmn;

            public sbyte[] stealth_detected = new sbyte[MAX_PLR];
        }
        //############################################################################//
        //############################################################################//
        //The unit info type
        public class typunitsdb
        {     
            public bool used;                          //Is used
            public int[] u_num, u_cas;                 //Game data - casulates, count

            public string typ, name;                   //Class, name
            public char descr;                         //Description //placing char instead of pchar

            public byte ptyp, level, num, siz;         //Passability, level, number, size
            public Int16 bldby;                        //Built by who
        
            public uint flags;                         //Attributes
            public bool isgun;                         //Separate gun
 
            public statrec bas;                        //Basic stats    
            public prodrec prod;                       //Basic resources

            public bool canbuild;                      //Builder
            public Int16 canbuildtyp;                  //What can it build

            public bool firemov;                       //Fires and moves?
            public byte fire_type, weapon_type;        //Firing type, shoots type
            public double blastlen, firlen;            //Animation data (?)

            //Storage
            public Int16 store_lnd, store_wtr, store_air, store_hmn;
        }
        //############################################################################//
        //Aux types
        public typunits[] ptypunitspa;
        public typunitsdb[] ptypunitsdba;

        /* LOL
        ptypunits=^typunits;
        ptypunitsdb=^typunitsdb;
        typunitspa=array of ptypunits;
        typunitsdba=array of typunitsdb;
        ptypunitspa=^typunitspa;
        ptypunitsdba=^typunitsdba;   
        */
        //Похоже, что можно обойтись здесь без указателей вообще. Через них передаются только модификации типов данных.
    }
}
