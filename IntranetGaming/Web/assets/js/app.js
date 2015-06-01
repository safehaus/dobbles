// Main app JS.

var api = (function () {

  var data = {};

  return {
    room: {
      join: function (name, roomCode) {
        data.name = name;
        data.roomCode = roomCode;
      }
    },
    data: data
  }
})();

var Fibbage = React.createClass({

  getInitialState: function () {
    var handleJoin = function () {
      this.setState({
        screen: WaitingForPlayers,
        props: {
          // TODO: get from service (call handleJoin with data)
          playerCount: 1
        }
      });
    }.bind(this);

    return {
      screen: JoinRoom,
      props: {
        onJoin: handleJoin
      }
    };
  },

  render: function () {
    return React.createElement(this.state.screen, this.state.props);
  }
});

var JoinRoom = React.createClass({
  propTypes: {
    onJoin: React.PropTypes.func.isRequired
  },

  render: function () {
    var join = function () {
      api.room.join(this.refs.name.getText(), this.refs.room.getText());
      // TODO: iff successful
      this.props.onJoin();
    }.bind(this);

    return (
      <div>
        <h2>Join a room</h2>
        <TextInput label='Room' ref='room'/>
        <TextInput label='Your Name' go='Join' action={join} ref='name'/>
      </div>
    );
  }
});

var WaitingForPlayers = React.createClass({
  propTypes: {
    playerCount: React.PropTypes.number.isRequired
  },

  render: function () {
    return (
      <div>
        <h2>Waiting for players</h2>
        <p>{this.props.playerCount} joined</p>
        <button>Everyone's here</button>
      </div>
    );
  }
});

var TextInput = React.createClass({
  propTypes: {
    label: React.PropTypes.string.isRequired,
    go: React.PropTypes.string,
    action: React.PropTypes.func
  },

  getText: function () {
    return React.findDOMNode(this.refs.text).value;
  },

  render: function () {
    return (
      <div>
        <label>
          {this.props.label}
          <input type='text' ref='text'/>
        </label>
        {this.props.go ? <button onClick={this.props.action}>{this.props.go}</button> : ''}
      </div>
    );
  }
});

(function () {
  React.render(React.createElement(Fibbage, {}), document.querySelector('#reactify'));
})();
