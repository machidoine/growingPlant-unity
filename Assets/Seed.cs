using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[Serializable]
public class Seed
{
    public int id;
    public SeedSkill skills;
    public Position position;
    public string direction;
    public string team;
    public string type;
}
/*
    [  
      {  
         "id":0,
         "skills":{  
            "attack":1
         },
         "position":{  
            "x":1,
            "y":1
         },
         "direction":"up",
         "team":"team3",
         "type":"seed"
      }
   ]
*/
