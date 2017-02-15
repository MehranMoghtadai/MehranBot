using System;
using Microsoft.Bot.Builder.FormFlow;

public enum YesNo { Yes = 1, No};
public enum ProductType { Auto = 1, Residential};
public enum CarOptions { Convertible = 1, SUV, EV };
public enum ColorOptions { Red = 1, White, Blue };

// For more information about this template visit http://aka.ms/azurebots-csharp-form
[Serializable]
public class BasicForm
{
    [Prompt("What is your {&}?")]
    public string Name { get; set; }

    [Prompt("Are you a current DT client {||}?")]
    public YesNo Client { get; set; }
    
    [Prompt("What is your {&} number?")]
    public long Account { get; set; }

    [Prompt("Are you part of an {&} group {||}?")]
    public YesNo Affinity { get; set; }

    [Prompt("What is your {&}?")]
    public string Group {get; set;}
    
    [Prompt("What product would you like to quote today {||}?")]
    public ProductType Product { get; set; }

    public static IForm<BasicForm> BuildForm()
    {
        // Builds an IForm<T> based on BasicForm
        return new FormBuilder<BasicForm>()
            .Message("Welcome to DT Insurance!")
            .Field(nameof(Name))
            .Field(nameof(Client))
            .Field(nameof(Account), (s) => s.Client == YesNo.Yes)
            .Field(nameof(Affinity))
            .Field(nameof(Group), (s) => s.Affinity == YesNo.Yes )
            .Field(nameof(Product))
            .Build();
    }

    public static IFormDialog<BasicForm> BuildFormDialog(FormOptions options = FormOptions.PromptInStart)
    {
        // Generated a new FormDialog<T> based on IForm<BasicForm>
        return FormDialog.FromForm(BuildForm, options);
    }
}
