// Main app JS.

var Fibbage = React.createClass({
  render: function () {
    return <div>Hello world</div>;
  }
});

(function () {
  React.render(React.createElement(Fibbage, {}), document.querySelector('#reactify'));
})();
