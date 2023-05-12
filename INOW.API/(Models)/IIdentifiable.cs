namespace INOW.API._Models_
{
    public interface IIdentifiable<TKey>
    {
        #region Members

        /// <summary>
        /// Chave de identificação
        /// </summary>
        TKey Id { get; set; }

        #endregion
    }
}
