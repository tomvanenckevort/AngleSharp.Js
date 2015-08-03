namespace AngleSharp.Scripting.JavaScript
{
    using AngleSharp.Dom.Html;
    using Jint;
    using Jint.Native;
    using Jint.Native.Object;
    using Jint.Runtime;
    using Jint.Runtime.Descriptors;
    using Jint.Runtime.Interop;
    using System;

    sealed partial class HTMLElementPrototype : HTMLElementInstance
    {
        public HTMLElementPrototype(Engine engine)
            : base(engine)
        {
            FastAddProperty("toString", Engine.AsValue(ToString), true, true, true);
            FastAddProperty("click", Engine.AsValue(Click), true, true, true);
            FastAddProperty("focus", Engine.AsValue(Focus), true, true, true);
            FastAddProperty("blur", Engine.AsValue(Blur), true, true, true);
            FastAddProperty("forceSpellCheck", Engine.AsValue(ForceSpellCheck), true, true, true);
            FastAddProperty("append", Engine.AsValue(Append), true, true, true);
            FastAddProperty("prepend", Engine.AsValue(Prepend), true, true, true);
            FastAddProperty("querySelector", Engine.AsValue(QuerySelector), true, true, true);
            FastAddProperty("querySelectorAll", Engine.AsValue(QuerySelectorAll), true, true, true);
            FastAddProperty("before", Engine.AsValue(Before), true, true, true);
            FastAddProperty("after", Engine.AsValue(After), true, true, true);
            FastAddProperty("replace", Engine.AsValue(Replace), true, true, true);
            FastAddProperty("remove", Engine.AsValue(Remove), true, true, true);
            FastSetProperty("lang", Engine.AsProperty(GetLang, SetLang));
            FastSetProperty("title", Engine.AsProperty(GetTitle, SetTitle));
            FastSetProperty("dir", Engine.AsProperty(GetDir, SetDir));
            FastSetProperty("dataset", Engine.AsProperty(GetDataset));
            FastSetProperty("translate", Engine.AsProperty(GetTranslate, SetTranslate));
            FastSetProperty("tabIndex", Engine.AsProperty(GetTabIndex, SetTabIndex));
            FastSetProperty("spellcheck", Engine.AsProperty(GetSpellcheck, SetSpellcheck));
            FastSetProperty("contentEditable", Engine.AsProperty(GetContentEditable, SetContentEditable));
            FastSetProperty("isContentEditable", Engine.AsProperty(GetIsContentEditable));
            FastSetProperty("hidden", Engine.AsProperty(GetHidden, SetHidden));
            FastSetProperty("draggable", Engine.AsProperty(GetDraggable, SetDraggable));
            FastSetProperty("accessKey", Engine.AsProperty(GetAccessKey, SetAccessKey));
            FastSetProperty("accessKeyLabel", Engine.AsProperty(GetAccessKeyLabel));
            FastSetProperty("contextMenu", Engine.AsProperty(GetContextMenu, SetContextMenu));
            FastSetProperty("dropzone", Engine.AsProperty(GetDropzone, SetDropzone));
            FastSetProperty("children", Engine.AsProperty(GetChildren));
            FastSetProperty("firstElementChild", Engine.AsProperty(GetFirstElementChild));
            FastSetProperty("lastElementChild", Engine.AsProperty(GetLastElementChild));
            FastSetProperty("childElementCount", Engine.AsProperty(GetChildElementCount));
            FastSetProperty("nextElementSibling", Engine.AsProperty(GetNextElementSibling));
            FastSetProperty("previousElementSibling", Engine.AsProperty(GetPreviousElementSibling));
            FastSetProperty("style", Engine.AsProperty(GetStyle, SetStyle));
        }

        public static HTMLElementPrototype CreatePrototypeObject(EngineInstance engine, HTMLElementConstructor constructor)
        {
            var obj = new HTMLElementPrototype(engine.Jint)
            {
                Prototype = engine.Constructors.Element.PrototypeObject,
                Extensible = true,
            };
            obj.FastAddProperty("constructor", constructor, true, false, true);
            return obj;
        }

        JsValue Click(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            reference.DoClick();
            return JsValue.Undefined;
        }

        JsValue Focus(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            reference.DoFocus();
            return JsValue.Undefined;
        }

        JsValue Blur(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            reference.DoBlur();
            return JsValue.Undefined;
        }

        JsValue ForceSpellCheck(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            reference.DoSpellCheck();
            return JsValue.Undefined;
        }

        JsValue Append(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var nodes = DomTypeConverter.ToNodeArray(arguments.At(0));
            reference.Append(nodes);
            return JsValue.Undefined;
        }

        JsValue Prepend(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var nodes = DomTypeConverter.ToNodeArray(arguments.At(0));
            reference.Prepend(nodes);
            return JsValue.Undefined;
        }

        JsValue QuerySelector(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var selectors = TypeConverter.ToString(arguments.At(0));
            return Engine.Select(reference.QuerySelector(selectors));
        }

        JsValue QuerySelectorAll(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var selectors = TypeConverter.ToString(arguments.At(0));
            return Engine.Select(reference.QuerySelectorAll(selectors));
        }

        JsValue Before(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var nodes = DomTypeConverter.ToNodeArray(arguments.At(0));
            reference.Before(nodes);
            return JsValue.Undefined;
        }

        JsValue After(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var nodes = DomTypeConverter.ToNodeArray(arguments.At(0));
            reference.After(nodes);
            return JsValue.Undefined;
        }

        JsValue Replace(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var nodes = DomTypeConverter.ToNodeArray(arguments.At(0));
            reference.Replace(nodes);
            return JsValue.Undefined;
        }

        JsValue Remove(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            reference.Remove();
            return JsValue.Undefined;
        }

        JsValue GetLang(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.Language);
        }

        void SetLang(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToString(argument);
            reference.Language = value;
        }

        JsValue GetTitle(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.Title);
        }

        void SetTitle(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToString(argument);
            reference.Title = value;
        }

        JsValue GetDir(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.Direction);
        }

        void SetDir(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToString(argument);
            reference.Direction = value;
        }

        JsValue GetDataset(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.Dataset);
        }


        JsValue GetTranslate(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.IsTranslated);
        }

        void SetTranslate(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToBoolean(argument);
            reference.IsTranslated = value;
        }

        JsValue GetTabIndex(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.TabIndex);
        }

        void SetTabIndex(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToInt32(argument);
            reference.TabIndex = value;
        }

        JsValue GetSpellcheck(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.IsSpellChecked);
        }

        void SetSpellcheck(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToBoolean(argument);
            reference.IsSpellChecked = value;
        }

        JsValue GetContentEditable(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.ContentEditable);
        }

        void SetContentEditable(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToString(argument);
            reference.ContentEditable = value;
        }

        JsValue GetIsContentEditable(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.IsContentEditable);
        }


        JsValue GetHidden(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.IsHidden);
        }

        void SetHidden(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToBoolean(argument);
            reference.IsHidden = value;
        }

        JsValue GetDraggable(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.IsDraggable);
        }

        void SetDraggable(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToBoolean(argument);
            reference.IsDraggable = value;
        }

        JsValue GetAccessKey(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.AccessKey);
        }

        void SetAccessKey(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToString(argument);
            reference.AccessKey = value;
        }

        JsValue GetAccessKeyLabel(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.AccessKeyLabel);
        }


        JsValue GetContextMenu(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.ContextMenu);
        }

        void SetContextMenu(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = DomTypeConverter.ToMenuElement(argument);
            reference.ContextMenu = value;
        }

        JsValue GetDropzone(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.DropZone);
        }

        void SetDropzone(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToString(argument);
            reference.DropZone.Value = value;
        }

        JsValue GetChildren(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.Children);
        }


        JsValue GetFirstElementChild(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.FirstElementChild);
        }


        JsValue GetLastElementChild(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.LastElementChild);
        }


        JsValue GetChildElementCount(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.ChildElementCount);
        }


        JsValue GetNextElementSibling(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.NextElementSibling);
        }


        JsValue GetPreviousElementSibling(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.PreviousElementSibling);
        }


        JsValue GetStyle(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            return Engine.Select(reference.Style);
        }

        void SetStyle(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLElementInstance>(Fail).RefHTMLElement;
            var value = TypeConverter.ToString(argument);
            reference.Style.CssText = value;
        }

        JsValue ToString(JsValue thisObj, JsValue[] arguments)
        {
            return "[object HTMLElement]";
        }

        void Fail(JsValue obsolete)
        {
            throw new JavaScriptException(Engine.TypeError);
        }
    }
}