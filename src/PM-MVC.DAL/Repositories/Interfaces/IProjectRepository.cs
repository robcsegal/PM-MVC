using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace PMMVC.DAL.Repositories.Interfaces
{
    [ServiceContract]
    public interface IProjectRepository
    {
        [OperationContract]
        void Instantiate();

        [OperationContract]
        Entities.Project GetEntityFromData(Data.ProjectManagement.Project project);

        [OperationContract]
        Entities.Project Get(int id);
    }
}
