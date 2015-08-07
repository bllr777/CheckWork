namespace AstonTech.Lottery
{
    /// <summary>
    /// Values correspond to the @QueryId in the EXECUTE stored procedures.
    /// The integer value needs to be passed to the procedures from DAL.
    /// </summary>
    public enum ExecuteTypeEnum
    {
        /// <summary>
        /// Defaults to none.
        /// </summary>
        None = 0,
        /// <summary>
        /// Insert an item into the database.
        /// </summary>
        InsertItem = 10,
        /// <summary>
        /// Update an item in the database.
        /// </summary>
        UpdateItem = 20,
        /// <summary>
        /// Delete an item in the datebase.
        /// </summary>
        DeleteItem = 30
    }
}
