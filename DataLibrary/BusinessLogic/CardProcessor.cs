using DataLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DataLibrary.DataAccess;

namespace DataLibrary.BusinessLogic
{
    public static class CardProcessor
    {

        public static int CreateElementCard(string elementType, string elementName, int inSan, int deSan, string isForce, string isInter, string elementDes, byte[] imagepath)
        {

            ElementModels data = new ElementModels

            {
                ElementType = elementType,
                ElementName = elementName,
                InSan = inSan,
                DeSan = deSan,
                IsForce = isForce,
                IsInter = isInter,
                ElementDes = elementDes,
                ImagePath = imagepath
                
            };

            string sql = @"insert into dbo.CardTBL(ElementType,ElementName,InSan,DeSan,IsForce,IsInter,ElementDes,ImagePath) 
                            values (@ElementType,@ElementName,@InSan,@DeSan,@IsForce,@IsInter,@ElementDes,@ImagePath)";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int UpdateElementCard(string elementType, string elementName, int inSan, int deSan, string isForce, string isInter, string elementDes)
        {

            ElementModels data = new ElementModels

            {
                ElementType = elementType,
                InSan = inSan,
                DeSan = deSan,
                IsForce = isForce,
                IsInter = isInter,
                ElementDes = elementDes,

            };

            string sql = @"UPDATE dbo.CardTBL SET ElementType = @ElementType,InSan=@InSan,DeSan=@DeSan,IsForce=@IsForce,IsInter=@IsInter,ElementDes=@ElementDes WHERE ElementName= '" + elementName + "'";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static int UpdateImage(byte[] imagepath, string elementName)
        {

            ElementModels data = new ElementModels

            {

                ImagePath = imagepath

            };

            string sql = @"UPDATE dbo.CardTBL SET ImagePath=@ImagePath WHERE ElementName= '" + elementName + "'";

            return SqlDataAccess.SaveData(sql, data);
        }


        public static List<ElementModels> LoadElementCard()
        {

            string sql = @"select ElementType,ElementName,InSan,DeSan,IsForce,IsInter,ElementDes,ImagePath from dbo.CardTBL;";

            return SqlDataAccess.LoadData<ElementModels>(sql);
        }

        public static List<ElementModels> LoadElementCardByName(string name)
        {

            string sql = @"select ElementType,ElementName,InSan,DeSan,IsForce,IsInter,ElementDes,ImagePath from dbo.CardTBL where ElementName= '"+ name + "';";

            return SqlDataAccess.LoadData<ElementModels>(sql);
        }


        public static List<ElementModels> DeleteElementCardByName(string name)
        {

            string sql = @"delete from dbo.CardTBL where ElementName= '" + name + "';";

            return SqlDataAccess.LoadData<ElementModels>(sql);
        }

    }
}
