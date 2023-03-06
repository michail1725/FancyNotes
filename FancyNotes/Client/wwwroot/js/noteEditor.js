var quill;

export function CreateNoteEditor(content) {
    quill = new Quill('#editor', {
        modules: {
            toolbar: [
                [{ header: [1, 2, false] }],
                ['bold', 'italic', 'underline'],
                /*['image']*/
            ]
        },
        placeholder: 'Напишите что-нибудь...',
        theme: 'snow'
    });
    quill.setContents(content);
}

export function GetEditorContent() {
    return quill.getContents();
}