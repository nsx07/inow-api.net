namespace INOW.API.Models
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
