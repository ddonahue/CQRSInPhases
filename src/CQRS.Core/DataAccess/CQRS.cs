using System.Configuration;

namespace CQRS.Core.DataAccess
{
    public partial class CQRSDataContext
	{
	    public CQRSDataContext() : base(ConfigurationManager.ConnectionStrings["CQRSConnectionString"].ConnectionString, mappingSource)
	    {
	    }
	}
}