/**
 * Javascript Support functions for Blazor proteus library
 * Proteus is a system for dynamic HTML displays which cna be laid out
 * on the fly
 */

var Proteus = {
    /**
     * @param {String} HTML representing a single element
     * @return {Element}
     * @example var td = htmlToElement('<td>foo</td>'),
     *              div = htmlToElement('<div><span>nested</span> <span>stuff</span></div>');
     */
    htmlToElement: function (html)
    {
        var template = document.createElement('template');
        html = html.trim(); // Never return a text node of whitespace as the result
        template.innerHTML = html;
        return template.content.firstChild;
    },
    
    
    /**
     * @param {String} HTML representing any number of sibling elements
     * @return {NodeList}
     * @example var rows = htmlToElements('<tr><td>foo</td></tr><tr><td>bar</td></tr>');
     */
    htmlToElements:function (html)  {
        var template = document.createElement('template');
        template.innerHTML = html;
        return template.content.childNodes;
    },

    getElementSize: function( el ) {
       let domRect = el.getBoundingClientRect()
        return [el.width,e.height];
    },
    setElementLayout(x,y,width,height){
        el.scrollLeft = el.offsetLeft - x;
        el.scrollTop = el.offsetTop - y;
    }
 
}

