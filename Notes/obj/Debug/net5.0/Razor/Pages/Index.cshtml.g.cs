#pragma checksum "C:\Users\prasa\source\repos\NotesRestApi\Notes\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bec51c1d41635cced61194220792260558d9275"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Notes.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace Notes.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\prasa\source\repos\NotesRestApi\Notes\Pages\_ViewImports.cshtml"
using Notes;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bec51c1d41635cced61194220792260558d9275", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c29453b1f4ace1a298e609e9dd9d3328205b8502", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\prasa\source\repos\NotesRestApi\Notes\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main class=""app-notes"">
    <section class=""app-notes-item app-notes-browse"">
        <ul class=""notes-browse-list"">
            <li class=""browse-list-item-add"">
                <button id=""add-notes-btn"">
                    <svg xmlns=""http://www.w3.org/2000/svg"" width=""48"" height=""48"" viewBox=""0 0 24 24"" fill=""none"" stroke=""#fff"" stroke-width=""1"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-plus-square""><rect x=""3"" y=""3"" width=""18"" height=""18"" rx=""2"" ry=""2""></rect><line x1=""12"" y1=""8"" x2=""12"" y2=""16""></line><line x1=""8"" y1=""12"" x2=""16"" y2=""12""></line></svg>
                </button>
            </li>
            <li><a id=""all-notes"">All notes</a></li>
        </ul>
    </section>
    <section class=""app-notes-item app-notes-list"">
        <ul class=""notes-list-group"" id=""notes-list-group"">
        </ul>
    </section>
    <section class=""app-notes-item app-notes-edit"">
        <textarea class=""notes-edit-text"" id=""notes-edit-text""></textarea>
    </section>
 ");
            WriteLiteral(@"   <div class=""controls"">
        <button id=""controls-delete""><svg xmlns=""http://www.w3.org/2000/svg"" width=""36"" height=""36"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-trash""><polyline points=""3 6 5 6 21 6""></polyline><path d=""M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2""></path></svg></button>
        <button id=""controls-copy""><svg xmlns=""http://www.w3.org/2000/svg"" width=""36"" height=""36"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""1.5"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-clipboard""><path d=""M16 4h2a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H6a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2h2""></path><rect x=""8"" y=""2"" width=""8"" height=""4"" rx=""1"" ry=""1""></rect></svg></button>
    </div>
</main>

<script>
    let allNotes = null;
    let timer = null;
    const notesListGroup = document.getElementById('notes-list-group');
    const addNote");
            WriteLiteral(@"sBtn = document.getElementById('add-notes-btn');
    const notesEditText = document.getElementById('notes-edit-text');
    const allNotesElement = document.getElementById('all-notes');
    
    addNotesBtn.addEventListener('click', (e => {
        console.log(allNotes);
        e.preventDefault();
        fetch(`http://localhost:5000/api/Notes`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ title: ""New Note"", description: """" })
        })
            .then(r => r.json())
            .then(newNote => {
                allNotes.push(newNote);
                const noteItem = document.createElement('li');
                noteItem.setAttribute(""data-key"", newNote.id);
                const noteItemLink = document.createElement('a');
                const noteTitle = document.createTextNode(newNote.title);
                noteItemLink.append(noteTitle);
                noteItem.append(n");
            WriteLiteral(@"oteItemLink);
                notesListGroup.prepend(noteItem);
                notesEditText.setAttribute(""data-notekey"", newNote.id);
                notesEditText.value = """";
                notesEditText.focus();
            });

    }));
    allNotesElement.addEventListener('click', e => {
        e.preventDefault();
        if (allNotes === null) {
            fetch(""http://localhost:5000/api/Notes"")
                .then(response => response.json())
                .then(data => {
                    allNotes = data;
                    data.forEach(item => {
                        const noteItem = document.createElement('li');
                        // key or id used to track note items
                        noteItem.setAttribute(""data-key"", item.id)
                        const noteItemLink = document.createElement('a');
                        const noteTitle = document.createTextNode(item.title);
                        noteItemLink.append(noteTitle);
                    ");
            WriteLiteral(@"    noteItem.append(noteItemLink);
                        notesListGroup.append(noteItem);
                    });

                }
                );
        } else { return;}
    });

    // Utilizing event's bubbling phase to handle click on every note list items with the parent element ('notes-list-group')
    notesListGroup.addEventListener('click', e => {
        let listItemElement = e.target.tagName === 'A' ? e.target.parentElement : e.target;
        const noteItemId = listItemElement.dataset.key;
        fetch(`http://localhost:5000/api/Notes/${noteItemId}`)
            .then(res => res.json())
            .then(data => {
                notesEditText.setAttribute(""data-notekey"", noteItemId)
                notesEditText.value = data.description;
            })
    });

    // Updating editText
    notesEditText.addEventListener('input', (e) => {
        if (timer === null) clearTimeout(timer);
        timer = setTimeout(() => {
            const noteId = notesEditText.da");
            WriteLiteral(@"taset.notekey;
            if (noteId !== undefined) {
                const currentNote = allNotes.find((n) => n.id === parseInt(noteId));
                currentNote.title = notesEditText.value.slice(0, 12);
                currentNote.description = notesEditText.value;
                const selector = ""[data-key="" + ""'"" + noteId + ""']"";
                const listItem = notesListGroup.querySelector(selector);
                listItem.querySelector('a').text = currentNote.title;
          
                fetch(`http://localhost:5000/api/Notes/${noteId}`, {
                    method: 'PATCH',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(currentNote)
                });
            }
        }, 1000)
    })

    allNotesElement.click();
</script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
