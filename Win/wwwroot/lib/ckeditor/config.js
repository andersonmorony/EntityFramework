/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
    config.toolbarGroups = [
        { name: 'clipboard', groups: ['clipboard', 'undo'] },
        { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
        { name: 'links', groups: ['links'] },
        { name: 'insert', groups: ['insert'] },
        { name: 'forms', groups: ['forms'] },
        { name: 'tools', groups: ['tools'] },
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
        { name: 'others', groups: ['others'] },
        '/',
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
        { name: 'styles', groups: ['styles'] },
        { name: 'colors', groups: ['colors'] },
        { name: 'about', groups: ['about'] }
    ];

    config.removeButtons = 'Underline,Subscript,Superscript,Image';

    config.extraPlugins = 'autolink';
    config.extraPlugins = 'autoembed';

    config.stylesSet = [
        { name: 'Custom Image', element: 'img', attributes: { 'class': 'myClass' } }
    ];

    config.removePlugins = 'elementspath';
    config.resize_enabled = false;
    // Simplify the dialog windows.
    config.removeDialogTabs = 'image:advanced;link:advanced';

};
