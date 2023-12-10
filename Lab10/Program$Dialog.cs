namespace Lab10
{
    public static partial class Program
    {
        private static ConsoleDialog MainDialog() => new(
            Messages.MainMenuWelcomeText,
            new() {
                new(
                    Messages.MainMenuOption1,
                    _ => Task1Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.MainMenuOption2,
                    _ => ConsoleDialog.ShowDialog(Task2Dialog())
                ),
                new(
                    Messages.MainMenuOption3,
                    _ => ConsoleDialog.ShowDialog(Task3Dialog())
                )
            }
        );

        private static ConsoleDialog Task2Dialog() => new(
            Messages.Task2WelcomeText,
            new() {
                new(
                    Messages.Task2Option1,
                    _ => Task2Option1Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.Task2Option2,
                    _ => Task2Option2Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.Task2Option3,
                    _ => Task2Option3Process(),
                    pauseAfterExecuted: true
                )
            }
        );

        private static ConsoleDialog Task3Dialog() => new(
            Messages.Task3WelcomeText,
            new() {
                new(
                    Messages.Task3Option1,
                    _ => Task3Option1Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.Task3Option2,
                    _ => Task3Option2Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.Task3Option3,
                    _ => Task3Option3Process(),
                    pauseAfterExecuted: true
                ),
                new(
                    Messages.Task3Option4,
                    _ => Task3Option4Process(),
                    pauseAfterExecuted: true
                )
            }
        );

        private static ConsoleDialog ChoiceInputMethodDialog() => new(
            Messages.ChoiceInputMethodDialogWelcomeText,
            new(){
                new(
                    Messages.ChoiceInputMethodDialogRandom,
                    _ => true,
                    exitAfterExecuted: true
                ),
                new(
                    Messages.ChoiceInputMethodDialogManual,
                    _ => false,
                    exitAfterExecuted: true
                ),
            }
        );
    }
}