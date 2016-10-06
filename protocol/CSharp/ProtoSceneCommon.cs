 
namespace Proto4z  
{ 
 
    public enum SCENE_TYPE : ushort 
    { 
        SCENE_TYPE_NONE = 0, //无效  
        SCENE_TYPE_HOME = 1, //主城  
        SCENE_TYPE_ARENA = 2, //竞技场  
        SCENE_TYPE_GUILD = 3, //公会  
        SCENE_TYPE_MASTER_INSTANCING = 4, //主线副本  
        SCENE_TYPE_BRANCH_INSTANCING = 5, //支线副本  
        SCENE_TYPE_MAX = 6, //最大类型数值. 扩展类型在该枚举之前插入新类型.  
    }; 
 
    public enum SCENE_STATUS : ushort 
    { 
        SCENE_STATUS_NONE = 0, //不存在  
        SCENE_STATUS_MATCHING = 1, //匹配中  
        SCENE_STATUS_CHOISE = 2, //选择英雄  
        SCENE_STATUS_ALLOCATE = 3, //服务器分配场景中  
        SCENE_STATUS_WAIT = 4, //等待玩家加入战场  
        SCENE_STATUS_ACTIVE = 5, //战斗中  
    }; 
 
    public class SceneGroupAvatarInfo: Proto4z.IProtoObject 
    {     
        //proto id   
        public const ushort protoID = 10000;  
        static public ushort getProtoID() { return 10000; } 
        static public string getProtoName() { return "SceneGroupAvatarInfo"; } 
        //members   
        public ulong areaID; //考虑混服情况,必须指定该玩家来自哪个当前区  
        public AvatarBaseInfo baseInfo; //玩家基础数据  
        public AvatarPropMap props; //角色属性数据  
        public ushort powerType; //组队权限: 0普通,1leader,2master  
        public string token; //scene服务器的口令, 该字段在广播给客户端时需要清空非自己所属的token,否则将会造成token公开.  
        public SceneGroupAvatarInfo()  
        { 
            areaID = 0;  
            baseInfo = new AvatarBaseInfo();  
            props = new AvatarPropMap();  
            powerType = 0;  
            token = "";  
        } 
        public SceneGroupAvatarInfo(ulong areaID, AvatarBaseInfo baseInfo, AvatarPropMap props, ushort powerType, string token) 
        { 
            this.areaID = areaID; 
            this.baseInfo = baseInfo; 
            this.props = props; 
            this.powerType = powerType; 
            this.token = token; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.areaID)); 
            if (this.baseInfo == null) this.baseInfo = new AvatarBaseInfo(); 
            data.AddRange(this.baseInfo.__encode()); 
            if (this.props == null) this.props = new AvatarPropMap(); 
            data.AddRange(this.props.__encode()); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI16(this.powerType)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeString(this.token)); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.areaID = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.baseInfo = new AvatarBaseInfo(); 
            this.baseInfo.__decode(binData, ref pos); 
            this.props = new AvatarPropMap(); 
            this.props.__decode(binData, ref pos); 
            this.powerType = Proto4z.BaseProtoObject.decodeUI16(binData, ref pos); 
            this.token = Proto4z.BaseProtoObject.decodeString(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class SceneGroupAvatarInfoArray : System.Collections.Generic.List<SceneGroupAvatarInfo>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new SceneGroupAvatarInfo(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
 
    public class SceneGroupAvatarInfoMap : System.Collections.Generic.Dictionary<ulong, SceneGroupAvatarInfo>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            foreach(var kv in this) 
            { 
                ret.AddRange(Proto4z.BaseProtoObject.encodeUI64(kv.Key)); 
                ret.AddRange(kv.Value.__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var key = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
                    var val = new SceneGroupAvatarInfo(); 
                    val.__decode(binData, ref pos); 
                    this.Add(key, val); 
                } 
            } 
            return pos; 
        } 
    } 
 
    public class SceneGroupInfo: Proto4z.IProtoObject //编队数据  
    {     
        //proto id   
        public const ushort protoID = 10001;  
        static public ushort getProtoID() { return 10001; } 
        static public string getProtoName() { return "SceneGroupInfo"; } 
        //members   
        public ulong groupID;  
        public ushort sceneType; //场景类型  
        public ushort sceneStatus; //状态  
        public ulong mapID;  
        public ulong lineID; //分线ID  
        public ulong sceneID; //场景实例ID  
        public string host; //服务器host  
        public ushort port; //服务器port  
        public SceneGroupAvatarInfoMap members; //队友数据  
        public ServiceIDMap invitees; //邀请列表, 如果需要丰富该功能可扩展类型信息  
        public SceneGroupInfo()  
        { 
            groupID = 0;  
            sceneType = 0;  
            sceneStatus = 0;  
            mapID = 0;  
            lineID = 0;  
            sceneID = 0;  
            host = "";  
            port = 0;  
            members = new SceneGroupAvatarInfoMap();  
            invitees = new ServiceIDMap();  
        } 
        public SceneGroupInfo(ulong groupID, ushort sceneType, ushort sceneStatus, ulong mapID, ulong lineID, ulong sceneID, string host, ushort port, SceneGroupAvatarInfoMap members, ServiceIDMap invitees) 
        { 
            this.groupID = groupID; 
            this.sceneType = sceneType; 
            this.sceneStatus = sceneStatus; 
            this.mapID = mapID; 
            this.lineID = lineID; 
            this.sceneID = sceneID; 
            this.host = host; 
            this.port = port; 
            this.members = members; 
            this.invitees = invitees; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.groupID)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI16(this.sceneType)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI16(this.sceneStatus)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.mapID)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.lineID)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.sceneID)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeString(this.host)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI16(this.port)); 
            if (this.members == null) this.members = new SceneGroupAvatarInfoMap(); 
            data.AddRange(this.members.__encode()); 
            if (this.invitees == null) this.invitees = new ServiceIDMap(); 
            data.AddRange(this.invitees.__encode()); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.groupID = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.sceneType = Proto4z.BaseProtoObject.decodeUI16(binData, ref pos); 
            this.sceneStatus = Proto4z.BaseProtoObject.decodeUI16(binData, ref pos); 
            this.mapID = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.lineID = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.sceneID = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.host = Proto4z.BaseProtoObject.decodeString(binData, ref pos); 
            this.port = Proto4z.BaseProtoObject.decodeUI16(binData, ref pos); 
            this.members = new SceneGroupAvatarInfoMap(); 
            this.members.__decode(binData, ref pos); 
            this.invitees = new ServiceIDMap(); 
            this.invitees.__decode(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class SceneGroupInfoArray : System.Collections.Generic.List<SceneGroupInfo>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new SceneGroupInfo(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
 
    public class SceneGroupInfoMap : System.Collections.Generic.Dictionary<ulong, SceneGroupInfo>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            foreach(var kv in this) 
            { 
                ret.AddRange(Proto4z.BaseProtoObject.encodeUI64(kv.Key)); 
                ret.AddRange(kv.Value.__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var key = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
                    var val = new SceneGroupInfo(); 
                    val.__decode(binData, ref pos); 
                    this.Add(key, val); 
                } 
            } 
            return pos; 
        } 
    } 
 
 
    public class EntityIDArray : System.Collections.Generic.List<ulong>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(Proto4z.BaseProtoObject.encodeUI64(this[i]));  
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    this.Add(Proto4z.BaseProtoObject.decodeUI64(binData, ref pos)); 
                } 
            } 
            return pos; 
        } 
    } 
 
    public class EPoint: Proto4z.IProtoObject 
    {     
        //proto id   
        public const ushort protoID = 10002;  
        static public ushort getProtoID() { return 10002; } 
        static public string getProtoName() { return "EPoint"; } 
        //members   
        public double x;  
        public double y;  
        public EPoint()  
        { 
            x = 0.0;  
            y = 0.0;  
        } 
        public EPoint(double x, double y) 
        { 
            this.x = x; 
            this.y = y; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.x)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.y)); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.x = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.y = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class EPoints : System.Collections.Generic.List<EPoint>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new EPoint(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
 
    public class SkillIDArray : System.Collections.Generic.List<ulong>, Proto4z.IProtoObject //技能ID数组  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(Proto4z.BaseProtoObject.encodeUI64(this[i]));  
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    this.Add(Proto4z.BaseProtoObject.decodeUI64(binData, ref pos)); 
                } 
            } 
            return pos; 
        } 
    } 
 
 
    public class BuffIDArray : System.Collections.Generic.List<ulong>, Proto4z.IProtoObject //buff ID 数组  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(Proto4z.BaseProtoObject.encodeUI64(this[i]));  
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    this.Add(Proto4z.BaseProtoObject.decodeUI64(binData, ref pos)); 
                } 
            } 
            return pos; 
        } 
    } 
 
    public enum ENTITY_STATE : ushort 
    { 
        ESTATE_NONE = 0, //无效  
        ESTATE_FREEZING = 1, //冻结, 不可被攻击,不可主动移动,攻击等  
        ESTATE_ACTIVE = 2, //活跃状态  
        ESTATE_LIE = 3, //跪, 不计死亡次数  
        ESTATE_DIED = 4, //死, 记死亡次数  
    }; 
 
    public enum ENTITY_TYPE : ushort 
    { 
        ETYPE_NONE = 0,  
        ETYPE_AVATAR = 1,  
        ETYPE_AI = 2,  
        ETYPE_FLIGHT = 3, //飞行道具  
    }; 
 
    public enum ENTITY_COLOR : ushort 
    { 
        ECOLOR_NONE = 0,  
        ECOLOR_RED = 1, //红方  
        ECOLOR_BLUE = 2, //蓝方  
        ECOLOR_NEUTRAL = 1000, //[0~ECOLOR_NEUTRAL)阵营相互敌对, [ECOLOR_NEUTRAL~)中立温和阵营  
    }; 
 
    public enum MoveAction : ushort 
    { 
        MACTION_IDLE = 0, //空闲  
        MACTION_FACE = 1, //朝向  
        MACTION_FOLLOW = 2, //跟随  
        MACTION_PATH = 3, //路径  
    }; 
 
    public enum SEARCH_METHOD : ushort 
    { 
        SEARCH_METHOD_DISTANCE = 0, //org 半径,360度扇形的优化  
        SEARCH_METHOD_SEACTOR = 1, //org 扇形  
        SEARCH_METHOD_RECT = 2, //org 矩形  
    }; 
 
    public enum SEARCH_TARGET : ulong 
    { 
        SEARCH_TARGET_NONE = 0, //无  
        SEARCH_TARGET_SELF = 1, //自身, 玩家或者AI  
        SEARCH_TARGET_ENEMY = 2, //敌人  
        SEARCH_TARGET_FRIEND = 3, //友方  
        SEARCH_TARGET_NEUTRAL = 4, //中立  
    }; 
 
    public enum SKILL_TYPE : ulong 
    { 
        SKILL_NONE = 0,  
        SKILL_AUTO = 1, //普攻  
        SKILL_PASSIVE = 2, //被动技能  
        SKILL_CAN_BREAK = 3, //可被中断  
        SKILL_CAN_MOVE = 4, //可移动  
        SKILL_PHYSICAL = 5, //物理攻击  
        SKILL_MAGIC = 6, //魔法攻击  
    }; 
 
    public enum SKILL_BEHAVIOUR : ulong 
    { 
        SKILL_BEHAVIOUR_NONE = 0,  
        SKILL_BEHAVIOUR_HIT = 1, //攻击  
        SKILL_BEHAVIOUR_TELEPORT_TARGET = 2, //瞬移到目标  
        SKILL_BEHAVIOUR_BREAK_MOVE = 3, //打断移动  
        SKILL_BEHAVIOUR_BREAK_SKILL = 4, //打断技能  
        SKILL_BEHAVIOUR_REMOVE_DEBUFF = 5, //驱散减益BUFF  
        SKILL_BEHAVIOUR_REMOVE_BUFF = 6, //驱散增益BUFF  
        SKILL_BEHAVIOUR_TRIGGER_BUFF = 7, //触发buff  
        SKILL_BEHAVIOUR_TRIGGER_SKILL = 8, //触发技能  
    }; 
 
    public enum BUFF_TYPE : ulong 
    { 
        BUFF_HALO = 1, //非表达可检索类型: 光环  
        BUFF_BUFF = 2, //非表达可检索类型: 增益buff  
        BUFF_DEBUFF = 3, //非表达可检索类型: 减益BUFF  
        BUFF_HIDE = 4, //非表达可检索类型: 客户端不表现  
        BUFF_SNEAK = 5, //潜行类型: 潜行 不会被非己方阵营的任何AOE技能搜索到  
        BUFF_HOLD_MOVE = 15, //控制: 禁止移动  
        BUFF_REVERSE_MOVE = 16, //控制: 移动反向  
        BUFF_SILENCE_AUTO_ATTACK = 17, //控制: 沉默普攻  
        BUFF_SILENCE_WITHOUT_AUTO_ATTACK = 18, //控制: 沉默非普攻技能  
        BUFF_SILENCE_PHYSICAL = 19, //控制: 沉默物理攻击  
        BUFF_SILENCE_MAGIC = 20, //控制: 沉默魔法攻击  
        BUFF_IMMUNE_MOVE = 25, //免疫: 免疫移动类控制  
        BUFF_IMMUNE_SILENCE = 26, //免疫: 免疫沉默  
        BUFF_IMMUNE_DEBUFF = 27, //免疫: 免疫添加DEBUFF, 指被地方添加不利buff  
        BUFF_IMMUNE_REMOVE_BUFF = 28, //免疫: 免疫驱散BUFF,指被敌方移除有益buff  
        BUFF_IMMUNE_PHYSICAL = 29, //免疫: 物攻免疫  
        BUFF_IMMUNE_MAGIC = 30, //免疫: 法攻免疫  
        BUFF_INC_HARM = 35, //属性加成: 最终扣血加成, value1加法, value2乘法  
        BUFF_INC_DAMAGE = 36, //属性加成: 伤害加成, value1加法, value2乘法  
        BUFF_INC_SPEED = 37, //属性加成: 速度加成, value1加法, value2乘法  
        BUFF_INC_SUCK_BLOOD = 38, //属性加成: 吸血加成 value1加法  
        BUFF_LIGHT_SKILL = 50, //持续性触发: value1为技能ID, value2为间隔, 用于光环类,持续触发类buff实现  
    }; 
 
    public class SearchInfo: Proto4z.IProtoObject 
    {     
        //proto id   
        public const ushort protoID = 10003;  
        static public ushort getProtoID() { return 10003; } 
        static public string getProtoName() { return "SearchInfo"; } 
        //members   
        public ushort searchMethod;  
        public ulong searchTarget;  
        public double rate; //概率  
        public double distance; //伤害距离  
        public double radian; //弧度或者宽度  
        public double offsetX; //坐标偏移量, 正数为x = x + offset  
        public double offsetY; //坐标偏移量, 正数为y = y + offset  
        public ulong targetMaxCount; //最大目标数  
        public SearchInfo()  
        { 
            searchMethod = 0;  
            searchTarget = 0;  
            rate = 0.0;  
            distance = 0.0;  
            radian = 0.0;  
            offsetX = 0.0;  
            offsetY = 0.0;  
            targetMaxCount = 0;  
        } 
        public SearchInfo(ushort searchMethod, ulong searchTarget, double rate, double distance, double radian, double offsetX, double offsetY, ulong targetMaxCount) 
        { 
            this.searchMethod = searchMethod; 
            this.searchTarget = searchTarget; 
            this.rate = rate; 
            this.distance = distance; 
            this.radian = radian; 
            this.offsetX = offsetX; 
            this.offsetY = offsetY; 
            this.targetMaxCount = targetMaxCount; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI16(this.searchMethod)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.searchTarget)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.rate)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.distance)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.radian)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.offsetX)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.offsetY)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.targetMaxCount)); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.searchMethod = Proto4z.BaseProtoObject.decodeUI16(binData, ref pos); 
            this.searchTarget = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.rate = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.distance = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.radian = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.offsetX = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.offsetY = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.targetMaxCount = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            return pos; 
        } 
    } 
 
    public class SkillBehaviour: Proto4z.IProtoObject //技能触发行为  
    {     
        //proto id   
        public const ushort protoID = 10004;  
        static public ushort getProtoID() { return 10004; } 
        static public string getProtoName() { return "SkillBehaviour"; } 
        //members   
        public ulong behaviour;  
        public double delay;  
        public SearchInfo search;  
        public SkillIDArray skills;  
        public BuffIDArray buffs;  
        public SkillBehaviour()  
        { 
            behaviour = 0;  
            delay = 0.0;  
            search = new SearchInfo();  
            skills = new SkillIDArray();  
            buffs = new BuffIDArray();  
        } 
        public SkillBehaviour(ulong behaviour, double delay, SearchInfo search, SkillIDArray skills, BuffIDArray buffs) 
        { 
            this.behaviour = behaviour; 
            this.delay = delay; 
            this.search = search; 
            this.skills = skills; 
            this.buffs = buffs; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.behaviour)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.delay)); 
            if (this.search == null) this.search = new SearchInfo(); 
            data.AddRange(this.search.__encode()); 
            if (this.skills == null) this.skills = new SkillIDArray(); 
            data.AddRange(this.skills.__encode()); 
            if (this.buffs == null) this.buffs = new BuffIDArray(); 
            data.AddRange(this.buffs.__encode()); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.behaviour = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.delay = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.search = new SearchInfo(); 
            this.search.__decode(binData, ref pos); 
            this.skills = new SkillIDArray(); 
            this.skills.__decode(binData, ref pos); 
            this.buffs = new BuffIDArray(); 
            this.buffs.__decode(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class SkillBehaviourArray : System.Collections.Generic.List<SkillBehaviour>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new SkillBehaviour(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
    public class SkillData: Proto4z.IProtoObject //技能  
    {     
        //proto id   
        public const ushort protoID = 10005;  
        static public ushort getProtoID() { return 10005; } 
        static public string getProtoName() { return "SkillData"; } 
        //members   
        public ulong skillID; //skillID  
        public ulong skillType; //SKILL_TYPE  
        public SkillBehaviourArray behaviours;  
        public double cd;  
        public SkillData()  
        { 
            skillID = 0;  
            skillType = 0;  
            behaviours = new SkillBehaviourArray();  
            cd = 0.0;  
        } 
        public SkillData(ulong skillID, ulong skillType, SkillBehaviourArray behaviours, double cd) 
        { 
            this.skillID = skillID; 
            this.skillType = skillType; 
            this.behaviours = behaviours; 
            this.cd = cd; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.skillID)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.skillType)); 
            if (this.behaviours == null) this.behaviours = new SkillBehaviourArray(); 
            data.AddRange(this.behaviours.__encode()); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.cd)); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.skillID = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.skillType = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.behaviours = new SkillBehaviourArray(); 
            this.behaviours.__decode(binData, ref pos); 
            this.cd = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            return pos; 
        } 
    } 
 
    public class BuffData: Proto4z.IProtoObject //buff  
    {     
        //proto id   
        public const ushort protoID = 10006;  
        static public ushort getProtoID() { return 10006; } 
        static public string getProtoName() { return "BuffData"; } 
        //members   
        public ulong buffID;  
        public ulong buffType; //buff类型  
        public double piletime; //最大叠加时间  
        public double keepTime; //保持时间  
        public double value1;  
        public double value2;  
        public BuffData()  
        { 
            buffID = 0;  
            buffType = 0;  
            piletime = 0.0;  
            keepTime = 0.0;  
            value1 = 0.0;  
            value2 = 0.0;  
        } 
        public BuffData(ulong buffID, ulong buffType, double piletime, double keepTime, double value1, double value2) 
        { 
            this.buffID = buffID; 
            this.buffType = buffType; 
            this.piletime = piletime; 
            this.keepTime = keepTime; 
            this.value1 = value1; 
            this.value2 = value2; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.buffID)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.buffType)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.piletime)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.keepTime)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.value1)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.value2)); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.buffID = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.buffType = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.piletime = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.keepTime = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.value1 = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.value2 = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            return pos; 
        } 
    } 
 
    public enum HARM_TYPE : ushort 
    { 
        HARM_TYPE_GENERAL = 0, //普通伤害  
        HARM_TYPE_MISS = 1, //闪避  
        HARM_TYPE_CRITICAL = 2, //暴击  
        HARM_TYPE_HILL = 3, //治疗  
    }; 
 
    public class HarmData: Proto4z.IProtoObject //伤害数据  
    {     
        //proto id   
        public const ushort protoID = 10007;  
        static public ushort getProtoID() { return 10007; } 
        static public string getProtoName() { return "HarmData"; } 
        //members   
        public ulong eid; //目标eid  
        public ushort type; //伤害类型HARM_TYPE  
        public double harm; //如果为正是伤害, 为负则是回血  
        public HarmData()  
        { 
            eid = 0;  
            type = 0;  
            harm = 0.0;  
        } 
        public HarmData(ulong eid, ushort type, double harm) 
        { 
            this.eid = eid; 
            this.type = type; 
            this.harm = harm; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.eid)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI16(this.type)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.harm)); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.eid = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.type = Proto4z.BaseProtoObject.decodeUI16(binData, ref pos); 
            this.harm = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class HarmDataArray : System.Collections.Generic.List<HarmData>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new HarmData(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
    public class SkillInfo: Proto4z.IProtoObject 
    {     
        //proto id   
        public const ushort protoID = 10008;  
        static public ushort getProtoID() { return 10008; } 
        static public string getProtoName() { return "SkillInfo"; } 
        //members   
        public ulong skillID;  
        public double startTime;  
        public double lastHitTime;  
        public ulong seq; //hit seq  
        public EPoint dst; //目标位置  
        public ulong foe; //锁定的目标  
        public SkillData data; //配置数据  
        public SkillInfo()  
        { 
            skillID = 0;  
            startTime = 0.0;  
            lastHitTime = 0.0;  
            seq = 0;  
            dst = new EPoint();  
            foe = 0;  
            data = new SkillData();  
        } 
        public SkillInfo(ulong skillID, double startTime, double lastHitTime, ulong seq, EPoint dst, ulong foe, SkillData data) 
        { 
            this.skillID = skillID; 
            this.startTime = startTime; 
            this.lastHitTime = lastHitTime; 
            this.seq = seq; 
            this.dst = dst; 
            this.foe = foe; 
            this.data = data; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.skillID)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.startTime)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.lastHitTime)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.seq)); 
            if (this.dst == null) this.dst = new EPoint(); 
            data.AddRange(this.dst.__encode()); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.foe)); 
            if (this.data == null) this.data = new SkillData(); 
            data.AddRange(this.data.__encode()); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.skillID = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.startTime = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.lastHitTime = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.seq = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.dst = new EPoint(); 
            this.dst.__decode(binData, ref pos); 
            this.foe = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.data = new SkillData(); 
            this.data.__decode(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class SkillInfoArray : System.Collections.Generic.List<SkillInfo>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new SkillInfo(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
    public class BuffInfo: Proto4z.IProtoObject 
    {     
        //proto id   
        public const ushort protoID = 10009;  
        static public ushort getProtoID() { return 10009; } 
        static public string getProtoName() { return "BuffInfo"; } 
        //members   
        public ulong eid; //施放该buff的entity id  
        public ulong skillID; //如果该buff是被技能触发的 则记录该技能, 被动技能是0  
        public ulong buffID;  
        public double start; //start (server)tick  
        public double lastTrigerTick; //lastTrigerTick  
        public BuffData data; //配置数据  
        public BuffInfo()  
        { 
            eid = 0;  
            skillID = 0;  
            buffID = 0;  
            start = 0.0;  
            lastTrigerTick = 0.0;  
            data = new BuffData();  
        } 
        public BuffInfo(ulong eid, ulong skillID, ulong buffID, double start, double lastTrigerTick, BuffData data) 
        { 
            this.eid = eid; 
            this.skillID = skillID; 
            this.buffID = buffID; 
            this.start = start; 
            this.lastTrigerTick = lastTrigerTick; 
            this.data = data; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.eid)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.skillID)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.buffID)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.start)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.lastTrigerTick)); 
            if (this.data == null) this.data = new BuffData(); 
            data.AddRange(this.data.__encode()); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.eid = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.skillID = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.buffID = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.start = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.lastTrigerTick = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.data = new BuffData(); 
            this.data.__decode(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class BuffInfoArray : System.Collections.Generic.List<BuffInfo>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new BuffInfo(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
    public class EntityInfo: Proto4z.IProtoObject //EntityInfo  
    {     
        //proto id   
        public const ushort protoID = 10010;  
        static public ushort getProtoID() { return 10010; } 
        static public string getProtoName() { return "EntityInfo"; } 
        //members   
        public ulong eid; //eid  
        public ushort color; //阵营  
        public ushort state; //状态  
        public EPoint pos; //当前坐标  
        public ushort moveAction; //状态  
        public EPoints movePath; //当前的移动路径  
        public ulong foe; //锁定的敌人  
        public ulong leader; //实体的老大, 如果是飞行道具 这个指向施放飞行道具的人  
        public ulong follow; //移动跟随的实体  
        public double curHP; //当前的血量  
        public EntityInfo()  
        { 
            eid = 0;  
            color = 0;  
            state = 0;  
            pos = new EPoint();  
            moveAction = 0;  
            movePath = new EPoints();  
            foe = 0;  
            leader = 0;  
            follow = 0;  
            curHP = 0.0;  
        } 
        public EntityInfo(ulong eid, ushort color, ushort state, EPoint pos, ushort moveAction, EPoints movePath, ulong foe, ulong leader, ulong follow, double curHP) 
        { 
            this.eid = eid; 
            this.color = color; 
            this.state = state; 
            this.pos = pos; 
            this.moveAction = moveAction; 
            this.movePath = movePath; 
            this.foe = foe; 
            this.leader = leader; 
            this.follow = follow; 
            this.curHP = curHP; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.eid)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI16(this.color)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI16(this.state)); 
            if (this.pos == null) this.pos = new EPoint(); 
            data.AddRange(this.pos.__encode()); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI16(this.moveAction)); 
            if (this.movePath == null) this.movePath = new EPoints(); 
            data.AddRange(this.movePath.__encode()); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.foe)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.leader)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.follow)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.curHP)); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.eid = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.color = Proto4z.BaseProtoObject.decodeUI16(binData, ref pos); 
            this.state = Proto4z.BaseProtoObject.decodeUI16(binData, ref pos); 
            this.pos = new EPoint(); 
            this.pos.__decode(binData, ref pos); 
            this.moveAction = Proto4z.BaseProtoObject.decodeUI16(binData, ref pos); 
            this.movePath = new EPoints(); 
            this.movePath.__decode(binData, ref pos); 
            this.foe = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.leader = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.follow = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.curHP = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class EntityInfoArray : System.Collections.Generic.List<EntityInfo>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new EntityInfo(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
    public class EntityControl: Proto4z.IProtoObject //EntityControl  
    {     
        //proto id   
        public const ushort protoID = 10011;  
        static public ushort getProtoID() { return 10011; } 
        static public string getProtoName() { return "EntityControl"; } 
        //members   
        public ulong eid; //eid  
        public double stateChageTick; //状态改变时间  
        public double extSpeed; //扩展速度  
        public double extBeginTime; //扩展速度的开始时间  
        public double extKeepTime; //扩展速度的保持时间  
        public EPoint spawnpoint; //出生点  
        public EPoint lastPos; //上一帧实体坐标, 如果是瞬移 则和pos相同  
        public SkillInfoArray skills; //技能数据  
        public BuffInfoArray buffs; //BUFF数据, 小标ID对应bufftype  
        public double diedTime; //实体死亡时间点 -1为永久, 仅飞行道具类有效  
        public int hitTimes; //实体碰撞 -1为永久, 仅飞行道具类有效  
        public double lastMoveTime; //最后一次移动时间  
        public EPoint lastClientPos; //最后一次客户端提交的坐标  
        public EntityControl()  
        { 
            eid = 0;  
            stateChageTick = 0.0;  
            extSpeed = 0.0;  
            extBeginTime = 0.0;  
            extKeepTime = 0.0;  
            spawnpoint = new EPoint();  
            lastPos = new EPoint();  
            skills = new SkillInfoArray();  
            buffs = new BuffInfoArray();  
            diedTime = 0.0;  
            hitTimes = 0;  
            lastMoveTime = 0.0;  
            lastClientPos = new EPoint();  
        } 
        public EntityControl(ulong eid, double stateChageTick, double extSpeed, double extBeginTime, double extKeepTime, EPoint spawnpoint, EPoint lastPos, SkillInfoArray skills, BuffInfoArray buffs, double diedTime, int hitTimes, double lastMoveTime, EPoint lastClientPos) 
        { 
            this.eid = eid; 
            this.stateChageTick = stateChageTick; 
            this.extSpeed = extSpeed; 
            this.extBeginTime = extBeginTime; 
            this.extKeepTime = extKeepTime; 
            this.spawnpoint = spawnpoint; 
            this.lastPos = lastPos; 
            this.skills = skills; 
            this.buffs = buffs; 
            this.diedTime = diedTime; 
            this.hitTimes = hitTimes; 
            this.lastMoveTime = lastMoveTime; 
            this.lastClientPos = lastClientPos; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.eid)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.stateChageTick)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.extSpeed)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.extBeginTime)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.extKeepTime)); 
            if (this.spawnpoint == null) this.spawnpoint = new EPoint(); 
            data.AddRange(this.spawnpoint.__encode()); 
            if (this.lastPos == null) this.lastPos = new EPoint(); 
            data.AddRange(this.lastPos.__encode()); 
            if (this.skills == null) this.skills = new SkillInfoArray(); 
            data.AddRange(this.skills.__encode()); 
            if (this.buffs == null) this.buffs = new BuffInfoArray(); 
            data.AddRange(this.buffs.__encode()); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.diedTime)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeI32(this.hitTimes)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeDouble(this.lastMoveTime)); 
            if (this.lastClientPos == null) this.lastClientPos = new EPoint(); 
            data.AddRange(this.lastClientPos.__encode()); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.eid = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.stateChageTick = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.extSpeed = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.extBeginTime = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.extKeepTime = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.spawnpoint = new EPoint(); 
            this.spawnpoint.__decode(binData, ref pos); 
            this.lastPos = new EPoint(); 
            this.lastPos.__decode(binData, ref pos); 
            this.skills = new SkillInfoArray(); 
            this.skills.__decode(binData, ref pos); 
            this.buffs = new BuffInfoArray(); 
            this.buffs.__decode(binData, ref pos); 
            this.diedTime = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.hitTimes = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            this.lastMoveTime = Proto4z.BaseProtoObject.decodeDouble(binData, ref pos); 
            this.lastClientPos = new EPoint(); 
            this.lastClientPos.__decode(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class EntityControlArray : System.Collections.Generic.List<EntityControl>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new EntityControl(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
    public class EntityReport: Proto4z.IProtoObject //EntityReport  
    {     
        //proto id   
        public const ushort protoID = 10012;  
        static public ushort getProtoID() { return 10012; } 
        static public string getProtoName() { return "EntityReport"; } 
        //members   
        public ulong eid; //eid  
        public ulong killOtherCount; //杀死其他玩家次数  
        public ulong killOtherTime; //杀死其他玩家的时间  
        public ulong diedCount; //死亡次数  
        public ulong topMultiKills; //最高连杀次数  
        public ulong curMultiKills; //当前连杀次数  
        public EntityReport()  
        { 
            eid = 0;  
            killOtherCount = 0;  
            killOtherTime = 0;  
            diedCount = 0;  
            topMultiKills = 0;  
            curMultiKills = 0;  
        } 
        public EntityReport(ulong eid, ulong killOtherCount, ulong killOtherTime, ulong diedCount, ulong topMultiKills, ulong curMultiKills) 
        { 
            this.eid = eid; 
            this.killOtherCount = killOtherCount; 
            this.killOtherTime = killOtherTime; 
            this.diedCount = diedCount; 
            this.topMultiKills = topMultiKills; 
            this.curMultiKills = curMultiKills; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.eid)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.killOtherCount)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.killOtherTime)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.diedCount)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.topMultiKills)); 
            data.AddRange(Proto4z.BaseProtoObject.encodeUI64(this.curMultiKills)); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.eid = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.killOtherCount = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.killOtherTime = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.diedCount = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.topMultiKills = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            this.curMultiKills = Proto4z.BaseProtoObject.decodeUI64(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class EntityReportArray : System.Collections.Generic.List<EntityReport>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new EntityReport(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
    public class EntityFullInfo: Proto4z.IProtoObject //EntityFullInfo  
    {     
        //proto id   
        public const ushort protoID = 10013;  
        static public ushort getProtoID() { return 10013; } 
        static public string getProtoName() { return "EntityFullInfo"; } 
        //members   
        public AvatarBaseInfo userInfo;  
        public EntityInfo info;  
        public EntityReport report;  
        public EntityFullInfo()  
        { 
            userInfo = new AvatarBaseInfo();  
            info = new EntityInfo();  
            report = new EntityReport();  
        } 
        public EntityFullInfo(AvatarBaseInfo userInfo, EntityInfo info, EntityReport report) 
        { 
            this.userInfo = userInfo; 
            this.info = info; 
            this.report = report; 
        } 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var data = new System.Collections.Generic.List<byte>(); 
            if (this.userInfo == null) this.userInfo = new AvatarBaseInfo(); 
            data.AddRange(this.userInfo.__encode()); 
            if (this.info == null) this.info = new EntityInfo(); 
            data.AddRange(this.info.__encode()); 
            if (this.report == null) this.report = new EntityReport(); 
            data.AddRange(this.report.__encode()); 
            return data; 
        } 
        public int __decode(byte[] binData, ref int pos) 
        { 
            this.userInfo = new AvatarBaseInfo(); 
            this.userInfo.__decode(binData, ref pos); 
            this.info = new EntityInfo(); 
            this.info.__decode(binData, ref pos); 
            this.report = new EntityReport(); 
            this.report.__decode(binData, ref pos); 
            return pos; 
        } 
    } 
 
 
    public class EntityFullInfoArray : System.Collections.Generic.List<EntityFullInfo>, Proto4z.IProtoObject  
    { 
        public System.Collections.Generic.List<byte> __encode() 
        { 
            var ret = new System.Collections.Generic.List<byte>(); 
            int len = (int)this.Count; 
            ret.AddRange(Proto4z.BaseProtoObject.encodeI32(len)); 
            for (int i = 0; i < this.Count; i++ ) 
            { 
                ret.AddRange(this[i].__encode()); 
            } 
            return ret; 
        } 
 
        public int __decode(byte[] binData, ref int pos) 
        { 
            int len = Proto4z.BaseProtoObject.decodeI32(binData, ref pos); 
            if(len > 0) 
            { 
                for (int i=0; i<len; i++) 
                { 
                    var data = new EntityFullInfo(); 
                    data.__decode(binData, ref pos); 
                    this.Add(data); 
                } 
            } 
            return pos; 
        } 
    } 
 
} 
 
 
