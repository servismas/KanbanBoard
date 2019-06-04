using DataAccessLayer.cs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfBussinesLogicLayerLibrary.ModelsDTO;

namespace WcfBussinesLogicLayerLibrary.Contracts
{
    [ServiceContract]
    interface ICreateEditeProfileContract
    {
        [OperationContract]
        void AddProfile(ProfileDTO newProfile);
        [OperationContract]
        void EditeProfile(ProfileDTO editeProfile);
        [OperationContract]
        ProfileDTO GetProfileDTO(Profile profile);
        [OperationContract]
        Profile GetProfile(ProfileDTO profileDTO);

    }
}
