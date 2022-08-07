namespace EMS.Core.Application.Assemblers
{
    public interface IDataTransferAssembler<TModel, TDataTransfer>
    {
        TDataTransfer AssembleDtoFrom(TModel obj);
    }
}
