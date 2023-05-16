using OpenAI;
using OpenAI.Chat;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using Meta.WitAi.TTS.Utilities;

public class OpenAITest : MonoBehaviour
{
    private List<Message> chatPrompts;
    private OpenAIClient api;
    public TMP_InputField input;
    public TextMeshProUGUI output;
    public string TextInput;
    public TTSSpeaker speaker;
    // Start is called before the first frame update
    async void Start()
    {
        api = new OpenAIClient("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");
        chatPrompts = new List<Message>
        {
            new Message(Role.System, "You are a helpful assistant working at a hotel called Hotel Sunny Beach."),
            new Message(Role.System, "Greet customers by saying \"Hi, welcome to the Hotel Sunny Beach\".")
        };
        await StartInitialPrompt();

    }
    async Task StartInitialPrompt()
    {
        var chatRequest = new ChatRequest(chatPrompts);
        var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
        Debug.Log(result.FirstChoice);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public async Task SendPrompt()
    {
        chatPrompts = new List<Message>
        {
            new Message(Role.User, input.text)
        };
        var chatRequest = new ChatRequest(chatPrompts);
        var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
        output.text = result.FirstChoice;
        speaker.Speak(result.FirstChoice);
    }
    
    public void ButtonPress()
    {
        SendPrompt();
    }
}