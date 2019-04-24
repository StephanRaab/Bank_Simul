namespace Bank_Simul {
    public class Account {
        public int Owner_Id { get; set; }
        public float Balance { get; set; }
        public string Type { get; set; }

        public static float Withdraw (float withdrawalAmount, Account startAccount) {
            //exceptions:
            if (startAccount.Type == "individual_invest" && withdrawalAmount > 1000){
                return startAccount.Balance;
            }
            if ((startAccount.Balance - withdrawalAmount) >= 0){
                startAccount.Balance -= withdrawalAmount;            
            }

            return startAccount.Balance;
        }

        public static float Deposit (float depositAmount, Account targetAccount) {
            targetAccount.Balance += depositAmount;
            return targetAccount.Balance;
        }

        public static void Transfer (float transferAmount, Account startAccount, Account targetAccount) {
            Withdraw (transferAmount, startAccount);
            if (startAccount.Type == "individual_invest" && transferAmount <= 1000){
                Deposit(transferAmount, targetAccount);
            }
            if (startAccount.Type != "individual_invest"){
                Deposit(transferAmount, targetAccount);
            }
        }
    }
}