using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ChatPayload {
    public string chat_id;
    public string ai_name;
    public string ai_identity;
    public string ai_rules;
    public string user_prompt;
}

[Serializable]
public class ChatResponse
{
    public string reply;
}


