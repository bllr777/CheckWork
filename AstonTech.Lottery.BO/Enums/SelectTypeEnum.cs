namespace AstonTech.Lottery
{
    /// <summary>
    /// Values correspond to the @QueryId in the SELECT (dbo.usp.GETXXX) stored procedure
    /// The integer value needs to be passed to the procedures from the DAL.
    /// </summary>
    public enum SelectTypeEnum
    {
        /// <summary>
        /// Defaults to none
        /// </summary>
        None = 0,
        /// <summary>
        /// Gets a single item from the database
        /// </summary>
        GetItem = 10,
        /// <summary>
        /// Gets a collection of items from the database
        /// </summary>
        GetCollection = 20,
        /// <summary>
        /// Gets a collection of items from the database by name/type.
        /// </summary>
        GetCollectionByName = 21
    }
}
