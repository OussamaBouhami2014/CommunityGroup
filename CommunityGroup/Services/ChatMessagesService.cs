//using CommunityGroup.Models;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CommunityGroup.Services
//{
//    public class ChatMessagesService
//    {
//        //Connecting to Web Service here
//        public ObservableCollection<DtoMessage> listChatMessages = new ObservableCollection<DtoMessage>();

//        public ObservableCollection<DtoMessage> GetChatMessages()
//        {
//            listChatMessages = new ObservableCollection<DtoMessage>
//            {
//                    new DtoMessage{
//                    MessageId = 1,
//                    MessageText = "Bonjour, Cv",
//                    //MessageImage = "",
//                    DateEnvoyer = DateTime.Now,
//                    DateReception = DateTime.Now,
//                    Vu = false,
//                    GroupeId = 0,
//                    UserId = 1,
//                    Statuts = "SentText",
//                    },

//                    new DtoMessage{
//                    MessageId = 2,
//                    MessageText = "Hay",
//                    //MessageImage = "empty",
//                    DateEnvoyer = DateTime.Now,
//                    DateReception = DateTime.Now,
//                    Vu = false,
//                    GroupeId = 0,
//                    UserId = 2,
//                    Statuts = "ReceivedText",
//                    },

//                    new ChatMessage{
//                    MessageId = 1,
//                    MessageText = "",
//                    MessageImage = "empty.png",
//                    DateEnvoyer = DateTime.Now,
//                    DateReception = DateTime.Now,
//                    Vu = false,
//                    GroupeId = 1,
//                    EmployeeId = 1,
//                    Statuts = "SentImage",
//                    },

//                    new ChatMessage{
//                    MessageId = 3,
//                    MessageText = "Cv Et Toi ..!!",
//                    //MessageImage = "",
//                    DateEnvoyer = DateTime.Now,
//                    DateReception = DateTime.Now,
//                    Vu = false,
//                    GroupeId = 2,
//                    EmployeeId = 2,
//                    Statuts = "ReceivedText",
//                    },

//                    new ChatMessage{
//                    MessageId = 4,
//                    MessageText = "Aussi",
//                    //MessageImage = "",
//                    DateEnvoyer = DateTime.Now,
//                    DateReception = DateTime.Now,
//                    Vu = false,
//                    GroupeId = 0,
//                    EmployeeId = 1,
//                    Statuts = "SentText",
//                    },

//                    new ChatMessage{
//                    MessageId = 1,
//                    MessageText = "",
//                    MessageImage = "empty.png",
//                    DateEnvoyer = DateTime.Now,
//                    DateReception = DateTime.Now,
//                    Vu = false,
//                    GroupeId = 0,
//                    EmployeeId = 1,
//                    Statuts = "ReceivedImage",
//                    },

//    };

//            //FillListChat();

//            return listChatMessages;
//        }

//        public void FillListChat()
//        {
//            foreach (var item in listChatMessages)
//            {
//                if (item.GroupeId != 0)
//                {
//                    listChatMessages.Remove(item);
//                }
//            }
//        }
//    }
//}