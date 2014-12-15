namespace PackageWebServer
{
    public partial class package
    {
        private enum PackageStatusType
        {
            Pending,
            Accepted,
            Shipped,
            Closed
        };

        public package()
        {
            this.id = 0;
            this.user_id = 0;
            this.content = "";
            this.status = (int)PackageStatusType.Pending;
        }
    }
}