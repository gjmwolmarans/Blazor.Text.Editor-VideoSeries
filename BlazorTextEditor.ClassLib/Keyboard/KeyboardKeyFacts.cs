using Microsoft.AspNetCore.Components.Web;

namespace BlazorTextEditor.ClassLib.Keyboard;

public static class KeyboardKeyFacts
{
    public static bool IsMetaKey(KeyboardEventArgs keyboardEventArgs)
    {
        return IsMetaKey(keyboardEventArgs.Key, keyboardEventArgs.Code);
    }
    
    public static bool IsMetaKey(string key, string code)
    {
        if (key.Length > 1 && !IsWhitespaceCode(code))
            return true;

        return false;
    }

    public static bool IsWhitespaceCharacter(char character)
    {
        switch (character)
        {
            case WhitespaceCharacters.TAB:
            case WhitespaceCharacters.CARRIAGE_RETURN:
            case WhitespaceCharacters.NEW_LINE:
            case WhitespaceCharacters.SPACE:
                return true;
            default:
                return false;
        }
    }
    
    public static bool IsPunctuationCharacter(char character)
    {
        switch (character)
        {
            case PunctuationCharacters.OPEN_CURLY_BRACE:
            case PunctuationCharacters.CLOSE_CURLY_BRACE:
            case PunctuationCharacters.OPEN_PARENTHESIS:
            case PunctuationCharacters.CLOSE_PARENTHESIS:
            case PunctuationCharacters.OPEN_SQUARE_BRACKET:
            case PunctuationCharacters.CLOSE_SQUARE_BRACKET:
            case PunctuationCharacters.PERIOD:
            case PunctuationCharacters.SEMICOLON:
            case PunctuationCharacters.EQUAL:
            case PunctuationCharacters.DOUBLE_QUOTE:
            case PunctuationCharacters.SINGLE_QUOTE:
            case PunctuationCharacters.OPEN_ARROW_BRACKET:
            case PunctuationCharacters.END_ARROW_BRACKET:
            case PunctuationCharacters.FORWARD_SLASH:
            case PunctuationCharacters.BACK_SLASH:
                return true;
            default:
                return false;
        }
    }

    public static class MetaKeys
    {
        public const string BACKSPACE = "Backspace";
        public const string ESCAPE = "Escape";
        public const string DELETE = "Delete";
        public const string F10 = "F10";
    }
    
    public static class WhitespaceCharacters
    {
        public const char TAB = '\t';
        public const char CARRIAGE_RETURN = '\r';
        public const char NEW_LINE = '\n';
        public const char SPACE = ' ';
    }
    
    public static bool IsWhitespaceCode(string code)
    {
        switch (code)
        {
            case WhitespaceCodes.TAB_CODE:
            case WhitespaceCodes.CARRIAGE_RETURN_CODE:
            case WhitespaceCodes.ENTER_CODE:
            case WhitespaceCodes.SPACE_CODE:
                return true;
            default:
                return false;
        }
    }

    
    public static class WhitespaceCodes
    {
        public const string TAB_CODE = "Tab";
        // TODO: Get CARRIAGE_RETURN_CODE code
        public const string CARRIAGE_RETURN_CODE = "";
        public const string ENTER_CODE = "Enter";
        public const string SPACE_CODE = "Space";
    }
    
    public static class PunctuationCharacters
    {
        public const char OPEN_CURLY_BRACE = '{';
        public const char CLOSE_CURLY_BRACE = '}';
        public const char OPEN_PARENTHESIS = '(';
        public const char CLOSE_PARENTHESIS = ')';
        public const char OPEN_SQUARE_BRACKET = '[';
        public const char CLOSE_SQUARE_BRACKET = ']';
        public const char PERIOD = '.';
        public const char SEMICOLON = ';';
        public const char EQUAL = '=';
        public const char DOUBLE_QUOTE = '\"';
        public const char SINGLE_QUOTE = '\'';
        public const char OPEN_ARROW_BRACKET = '<';
        public const char END_ARROW_BRACKET = '>';
        public const char FORWARD_SLASH = '/';
        public const char BACK_SLASH = '\\';
    }
    
    public static class MovementKeys
    {
        public const string ARROW_LEFT = "ArrowLeft";
        public const string ARROW_DOWN = "ArrowDown";
        public const string ARROW_UP = "ArrowUp";
        public const string ARROW_RIGHT = "ArrowRight";
        public const string HOME = "Home";
        public const string END = "End";
    }

    public static class AlternateMovementKeys
    {
        public const string ARROW_LEFT = "h";
        public const string ARROW_DOWN = "j";
        public const string ARROW_UP = "k";
        public const string ARROW_RIGHT = "l";
    }

    public static class LetterKeyCodes
    {
        public static readonly KeyboardKeyCode KeyA = new("a", "KeyA");
        public static readonly KeyboardKeyCode KeyB = new("b", "KeyB");
        public static readonly KeyboardKeyCode KeyC = new("c", "KeyC");
        public static readonly KeyboardKeyCode KeyD = new("d", "KeyD");
        public static readonly KeyboardKeyCode KeyE = new("e", "KeyE");
        public static readonly KeyboardKeyCode KeyF = new("f", "KeyF");
        public static readonly KeyboardKeyCode KeyG = new("g", "KeyG");
        public static readonly KeyboardKeyCode KeyH = new("h", "KeyH");
        public static readonly KeyboardKeyCode KeyI = new("i", "KeyI");
        public static readonly KeyboardKeyCode KeyJ = new("j", "KeyJ");
        public static readonly KeyboardKeyCode KeyK = new("k", "KeyK");
        public static readonly KeyboardKeyCode KeyL = new("l", "KeyL");
        public static readonly KeyboardKeyCode KeyM = new("m", "KeyM");
        public static readonly KeyboardKeyCode KeyN = new("n", "KeyN");
        public static readonly KeyboardKeyCode KeyO = new("o", "KeyO");
        public static readonly KeyboardKeyCode KeyP = new("p", "KeyP");
        public static readonly KeyboardKeyCode KeyQ = new("q", "KeyQ");
        public static readonly KeyboardKeyCode KeyR = new("r", "KeyR");
        public static readonly KeyboardKeyCode KeyS = new("s", "KeyS");
        public static readonly KeyboardKeyCode KeyT = new("t", "KeyT");
        public static readonly KeyboardKeyCode KeyU = new("u", "KeyU");
        public static readonly KeyboardKeyCode KeyV = new("v", "KeyV");
        public static readonly KeyboardKeyCode KeyW = new("w", "KeyW");
        public static readonly KeyboardKeyCode KeyX = new("x", "KeyX");
        public static readonly KeyboardKeyCode KeyY = new("y", "KeyY");
        public static readonly KeyboardKeyCode KeyZ = new("z", "KeyZ");
    }
    
    public static KeyboardKeyCode GetLetterKeyCode(char character)
    {        
        var letterKeyCode = character switch
        {
            'a' => LetterKeyCodes.KeyA,
            'b' => LetterKeyCodes.KeyB,
            'c' => LetterKeyCodes.KeyC,
            'd' => LetterKeyCodes.KeyD,
            'e' => LetterKeyCodes.KeyE,
            'f' => LetterKeyCodes.KeyF,
            'g' => LetterKeyCodes.KeyG,
            'h' => LetterKeyCodes.KeyH,
            'i' => LetterKeyCodes.KeyI,
            'j' => LetterKeyCodes.KeyJ,
            'k' => LetterKeyCodes.KeyK,
            'l' => LetterKeyCodes.KeyL,
            'm' => LetterKeyCodes.KeyM,
            'n' => LetterKeyCodes.KeyN,
            'o' => LetterKeyCodes.KeyO,
            'p' => LetterKeyCodes.KeyP,
            'q' => LetterKeyCodes.KeyQ,
            'r' => LetterKeyCodes.KeyR,
            's' => LetterKeyCodes.KeyS,
            't' => LetterKeyCodes.KeyT,
            'u' => LetterKeyCodes.KeyU,
            'v' => LetterKeyCodes.KeyV,
            'w' => LetterKeyCodes.KeyW,
            'x' => LetterKeyCodes.KeyX,
            'y' => LetterKeyCodes.KeyY,
            'z' => LetterKeyCodes.KeyZ,
            _ => throw new ApplicationException($"Unrecognized character input: '{character}'")
        };

        return letterKeyCode with { IsLower = char.IsLower(character) };
    }

    public static bool CheckIsAlternateContextMenuEvent(KeyDownEventRecord keyDownEventRecord)
    {
        string keyOne = "F10";
        string keyTwo = "f10";

        return (keyDownEventRecord.Key == keyOne || keyDownEventRecord.Key == keyTwo)
               && keyDownEventRecord.ShiftWasPressed;
    }
    
    public static bool CheckIsAlternateContextMenuEvent(string key, string code, bool shiftWasPressed, bool altWasPressed)
    {
        string keyOne = "F10";
        string keyTwo = "f10";

        var wasShiftF10 = (key == keyOne || key == keyTwo)  
                          && shiftWasPressed;
        
        var wasAltPeriod = (key == ".")
                          && altWasPressed;

        return wasShiftF10 || wasAltPeriod;
    }
    
    public static bool CheckIsContextMenuEvent(string key, string code, bool shiftWasPressed, bool altWasPressed)
    {
        string keyOne = "ContextMenu";

        return key == keyOne ||
               CheckIsAlternateContextMenuEvent(key, code, shiftWasPressed, altWasPressed);
    }

    public static bool IsMovementKey(KeyDownEventRecord onKeyDownEventArgs)
    {
        switch (onKeyDownEventArgs.Key)
        {
            case MovementKeys.ARROW_LEFT:
            case MovementKeys.ARROW_DOWN:
            case MovementKeys.ARROW_UP:
            case MovementKeys.ARROW_RIGHT:
            case MovementKeys.HOME:
            case MovementKeys.END:
                return true;
            default:
                return false;
        }
    }
    
    public static bool IsMovementKey(string key)
    {
        switch (key)
        {
            case MovementKeys.ARROW_LEFT:
            case MovementKeys.ARROW_DOWN:
            case MovementKeys.ARROW_UP:
            case MovementKeys.ARROW_RIGHT:
            case MovementKeys.HOME:
            case MovementKeys.END:
                return true;
            default:
                return false;
        }
    }
    
    public static bool IsAlternateMovementKey(KeyDownEventRecord onKeyDownEventArgs)
    {
        switch (onKeyDownEventArgs.Key)
        {
            case AlternateMovementKeys.ARROW_LEFT:
            case AlternateMovementKeys.ARROW_DOWN:
            case AlternateMovementKeys.ARROW_UP:
            case AlternateMovementKeys.ARROW_RIGHT:
                return true;
            default:
                return false;
        }
    }

    public static char ConvertWhitespaceCodeToCharacter(string code)
    {
        switch (code)
        {
            case WhitespaceCodes.TAB_CODE:
                return '\t';
            case WhitespaceCodes.ENTER_CODE:
                return '\n';
            case WhitespaceCodes.SPACE_CODE:
                return ' ';
            case WhitespaceCodes.CARRIAGE_RETURN_CODE:
                return '\r';
            default: 
                throw new ApplicationException($"Unrecognized Whitespace code of: {code}");
        }
    }

    public static bool IsLineEndingCharacter(char character)
    {
        return character switch
        {
            KeyboardKeyFacts.WhitespaceCharacters.NEW_LINE => true,
            KeyboardKeyFacts.WhitespaceCharacters.CARRIAGE_RETURN => true,
            _ => false
        };
    }
}