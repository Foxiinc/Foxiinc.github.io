using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DefaultNamespace
{
    public static class SaveMethods
    {
        public static void Save(DataForSave dataForSave)
        {
            BinaryFormatter bf = new BinaryFormatter();

            DataForSave data = Load();
            
            FileStream file = new FileStream(Application.persistentDataPath
                                             + "/MySaveData.dat", FileMode.OpenOrCreate, FileAccess.Write,
                FileShare.None);

            data.CoinCount += dataForSave.CoinCount;
            
            bf.Serialize(file, data);
            
            file.Close();
        }

        public static DataForSave Load()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                
                FileStream file = 
                    new FileStream(Application.persistentDataPath
                                   + "/MySaveData.dat", FileMode.Open, FileAccess.Read,
                        FileShare.None);
                
                DataForSave data = (DataForSave)bf.Deserialize(file);
                
                file.Close();
                
                return data;
            }
            catch (Exception e)
            {
                return new DataForSave
                {
                    CoinCount = 0
                };
            }
        }

        public static void Reset()
        {
            if (File.Exists(Application.persistentDataPath 
                            + "/MySaveData.dat"))
            {
                File.Delete(Application.persistentDataPath 
                            + "/MySaveData.dat");
            }
        }
    }
}