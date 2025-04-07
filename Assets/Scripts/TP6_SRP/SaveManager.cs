using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using UnityEngine;
using System.IO.Compression;


namespace TP6
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private string saveFolderName = "SaveData";
        [SerializeField] private string encryptionKey = "GameSaveEncryptKey";
        [SerializeField] private bool useCompression = true;
        [SerializeField] private bool useEncryption = true;

        // Référence à l'UI pour afficher les messages
        [SerializeField] private GameObject saveLoadMessagePanel;
        [SerializeField] private UnityEngine.UI.Text messageText;

        private string SaveFolderPath => Path.Combine(Application.persistentDataPath, saveFolderName);

        // Données du joueur (normalement cette classe serait séparée)
        [Serializable]
        public class PlayerData
        {
            public string playerName;
            public int level;
            public float health;
            public Vector3 position;
            public Quaternion rotation;
            public int[] inventory;
            public int currency;
            // etc.
        }

        private void Start()
        {
            // Créer le dossier de sauvegarde s'il n'existe pas
            if (!Directory.Exists(SaveFolderPath))
            {
                Directory.CreateDirectory(SaveFolderPath);
            }
        }

        // Sauvegarde les données du joueur
        public void SaveGame(PlayerData playerData, string fileName)
        {
            try
            {
                // Sérialisation des données en JSON
                string jsonData = JsonUtility.ToJson(playerData, true);
                byte[] rawData = Encoding.UTF8.GetBytes(jsonData);

                // Compression des données si activée
                if (useCompression)
                {
                    rawData = CompressData(rawData);
                }

                // Chiffrement des données si activé
                if (useEncryption)
                {
                    rawData = EncryptData(rawData);
                }

                // Sauvegarde dans un fichier
                string filePath = Path.Combine(SaveFolderPath, fileName + ".sav");
                File.WriteAllBytes(filePath, rawData);

                // Affiche un message de réussite
                ShowMessage($"Sauvegarde réussie dans {fileName}.sav");
                Debug.Log($"Données sauvegardées dans {filePath}");
            }
            catch (Exception e)
            {
                // Gestion des erreurs
                ShowMessage($"Erreur lors de la sauvegarde : {e.Message}");
                Debug.LogError($"Erreur lors de la sauvegarde : {e.Message}");
            }
        }

        // Charge les données du joueur
        public PlayerData LoadGame(string fileName)
        {
            try
            {
                string filePath = Path.Combine(SaveFolderPath, fileName + ".sav");

                if (!File.Exists(filePath))
                {
                    ShowMessage($"Fichier de sauvegarde {fileName}.sav introuvable");
                    Debug.LogWarning($"Fichier de sauvegarde introuvable: {filePath}");
                    return null;
                }

                // Lecture du fichier
                byte[] rawData = File.ReadAllBytes(filePath);

                // Déchiffrement des données si nécessaire
                if (useEncryption)
                {
                    rawData = DecryptData(rawData);
                }

                // Décompression des données si nécessaire
                if (useCompression)
                {
                    rawData = DecompressData(rawData);
                }

                // Désérialisation des données
                string jsonData = Encoding.UTF8.GetString(rawData);
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);

                // Affiche un message de réussite
                ShowMessage($"Chargement réussi de {fileName}.sav");
                Debug.Log($"Données chargées depuis {filePath}");

                return playerData;
            }
            catch (Exception e)
            {
                // Gestion des erreurs
                ShowMessage($"Erreur lors du chargement : {e.Message}");
                Debug.LogError($"Erreur lors du chargement : {e.Message}");
                return null;
            }
        }

        // Supprime un fichier de sauvegarde
        public bool DeleteSaveFile(string fileName)
        {
            try
            {
                string filePath = Path.Combine(SaveFolderPath, fileName + ".sav");

                if (!File.Exists(filePath))
                {
                    ShowMessage($"Fichier de sauvegarde {fileName}.sav introuvable");
                    return false;
                }

                File.Delete(filePath);
                ShowMessage($"Sauvegarde {fileName}.sav supprimée");
                return true;
            }
            catch (Exception e)
            {
                ShowMessage($"Erreur lors de la suppression : {e.Message}");
                Debug.LogError($"Erreur lors de la suppression : {e.Message}");
                return false;
            }
        }

        // Liste toutes les sauvegardes disponibles
        public string[] ListSaveFiles()
        {
            try
            {
                if (!Directory.Exists(SaveFolderPath))
                {
                    return new string[0];
                }

                string[] filePaths = Directory.GetFiles(SaveFolderPath, "*.sav");

                // Convertir les chemins complets en noms de fichiers sans extension
                for (int i = 0; i < filePaths.Length; i++)
                {
                    filePaths[i] = Path.GetFileNameWithoutExtension(filePaths[i]);
                }

                return filePaths;
            }
            catch (Exception e)
            {
                Debug.LogError($"Erreur lors de la liste des sauvegardes : {e.Message}");
                return new string[0];
            }
        }

        #region Compression
        // Compresse les données
        private byte[] CompressData(byte[] data)
        {
            using (MemoryStream output = new MemoryStream())
            {
                using (GZipStream gzip = new GZipStream(output, CompressionMode.Compress))
                {
                    gzip.Write(data, 0, data.Length);
                }
                return output.ToArray();
            }
        }

        // Décompresse les données
        private byte[] DecompressData(byte[] data)
        {
            using (MemoryStream input = new MemoryStream(data))
            {
                using (GZipStream gzip = new GZipStream(input, CompressionMode.Decompress))
                {
                    using (MemoryStream output = new MemoryStream())
                    {
                        gzip.CopyTo(output);
                        return output.ToArray();
                    }
                }
            }
        }
        #endregion

        #region Encryption
        // Chiffre les données
        private byte[] EncryptData(byte[] data)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] key = Encoding.UTF8.GetBytes(encryptionKey.PadRight(16, '*').Substring(0, 16));
                aes.Key = key;
                aes.IV = new byte[16]; // IV simplifié pour l'exemple

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    return PerformCrypto(data, encryptor);
                }
            }
        }

        // Déchiffre les données
        private byte[] DecryptData(byte[] data)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] key = Encoding.UTF8.GetBytes(encryptionKey.PadRight(16, '*').Substring(0, 16));
                aes.Key = key;
                aes.IV = new byte[16]; // IV simplifié pour l'exemple

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    return PerformCrypto(data, decryptor);
                }
            }
        }

        // Effectue la transformation cryptographique
        private byte[] PerformCrypto(byte[] data, ICryptoTransform transform)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                    return ms.ToArray();
                }
            }
        }
        #endregion

        #region UI Messages
        // Affiche un message à l'utilisateur
        private void ShowMessage(string message)
        {
            if (saveLoadMessagePanel != null && messageText != null)
            {
                messageText.text = message;
                saveLoadMessagePanel.SetActive(true);

                // Masquer le message après 3 secondes
                StopAllCoroutines();
                StartCoroutine(HideMessageAfterDelay(3f));
            }
        }

        // Masque le message après un délai
        private System.Collections.IEnumerator HideMessageAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (saveLoadMessagePanel != null)
            {
                saveLoadMessagePanel.SetActive(false);
            }
        }
        #endregion
    }
}