/* jshint esversion: 6 */
//#region konamicode
const pressed = [];
let up = 38, down = 40, left = 37, right = 39, A = 65, B = 66;
const secretCode = [up, up, down, down, left, right, left, right, A, B];
window.addEventListener('keyup', (e) => {
  pressed.push(e.keyCode);
  pressed.splice(-secretCode.length - 1, pressed.length - secretCode.length);
  if (pressed.join('').includes(secretCode.join(''))) {
    console.log('%cDING DING!', 'color: #ffc600; font-size: 48px; font-variant: smallcaps;');
    negativar();
  }
});
//#endregion konamicode

//#region negative
function negativar() {
  // the css we are going to inject
  var css = 'html {-webkit-filter: invert(100%);' +
    '-moz-filter: invert(100%);' +
    '-o-filter: invert(100%);' +
    '-ms-filter: invert(100%); ' +
    'filter: invert(100%); ' +
    'filter: url("data:image/svg+xml;utf8,<svg xmlns=\'http://www.w3.org/2000/svg\'><filter id=\'invert\'><feColorMatrix in=\'SourceGraphic\' type=\'matrix\' values=\'-1 0 0 0 1 0 -1 0 0 1 0 0 -1 0 1 0 0 0 1 0\'/></filter></svg>#invert"); }',

    head = document.getElementsByTagName('head')[0],
    style = document.createElement('style');

  // a hack, so you can "invert back" clicking the bookmarklet again
  if (!window.counter) { window.counter = 1; } else {
    window.counter++;
    if (window.counter % 2 == 0) { css = 'html {-webkit-filter: invert(0%); -moz-filter:    invert(0%); -o-filter: invert(0%); -ms-filter: invert(0%); }' }
  }

  style.type = 'text/css';
  if (style.styleSheet) {
    style.styleSheet.cssText = css;
  } else {
    style.appendChild(document.createTextNode(css));
  }

  //injecting the css to the head
  head.appendChild(style);
}
//credit: https://stackoverflow.com/users/549913/renanlf
//#endregion negative