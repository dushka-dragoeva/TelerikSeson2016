namespace AcademyRPG
{
    public class ExtendedEngine : Engine
    {
        public override void ExecuteCreateObjectCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "knight":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Knight(name, position, owner));
                        break;
                    }

                case "house":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        int owner = int.Parse(commandWords[3]);
                        this.AddObject(new House(position, owner));
                        break;
                    }

                case "giant":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Giant (name, position));
                        break;
                    }

                case "rock":
                    {
                        int size = int.Parse(commandWords[2]);
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Rock (size, position));
                        break;
                    }

                case "ninja":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Ninja(name, position, owner));
                        break;
                    }

                default:
                    base.ExecuteCreateObjectCommand(commandWords);
                    break;
            }
        }

        //public virtual void ExecuteControllableCommand(string[] commandWords)
        //{
        //    string controllableName = commandWords[0];
        //    IControllable current = null;

        //    for (int i = 0; i < this.controllables.Count; i++)
        //    {
        //        if (controllableName == this.controllables[i].Name)
        //        {
        //            current = this.controllables[i];
        //        }
        //    }

        //    if (current != null)
        //    {
        //        switch (commandWords[1])
        //        {
        //            case "go":
        //                {
        //                    HandleGoCommand(commandWords, current);
        //                    break;
        //                }
        //            case "attack":
        //                {
        //                    HandleAttackCommand(current);
        //                    break;
        //                }
        //            case "gather":
        //                {
        //                    HandleGatherCommand(current);
        //                    break;
        //                }
        //        }
        //    }
        //}
    }
}
