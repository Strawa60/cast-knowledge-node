(function() {
	
	jsPlumb.ready(function() {

	    var instance = jsPlumb.getInstance({
	        // default drag options
	        DragOptions: { cursor: 'pointer', zIndex: 2000 },
	        // the overlays to decorate each connection with.  note that the label overlay uses a function to generate the label text; in this
	        // case it returns the 'labelText' member that we set on each connection in the 'init' method below.
	        ConnectionOverlays: [
                ["Arrow", { location: 1 }],
                ["Label", {
                    location: 0.1,
                    id: "label",
                    cssClass: "aLabel"
                }]
	        ],
	        Container: "drag-drop"
	    });

	    // this is the paint style for the connecting lines..
	    var connectorPaintStyle = {
	        lineWidth: 4,
	        strokeStyle: "#61B7CF",
	        joinstyle: "round",
	        outlineColor: "white",
	        outlineWidth: 2
	    },
        // .. and this is the hover style. 
        connectorHoverStyle = {
            lineWidth: 4,
            strokeStyle: "#216477",
            outlineWidth: 2,
            outlineColor: "white"
        },
        endpointHoverStyle = {
            fillStyle: "#216477",
            strokeStyle: "#216477"
        },
        // the definition of source endpoints (the small blue ones)
	    sourceEndpoint = {
	        endpoint: "Dot",
	        paintStyle: {
	            strokeStyle: "#61B7CF",
	            fillStyle: "transparent",
	            radius: 7,
	            lineWidth: 3
	        },
	        isSource: true,
            isTarget: true,
	        connector: ["Flowchart", { stub: [40, 60], gap: 10, cornerRadius: 5, alwaysRespectStubs: true }],
	        connectorStyle: connectorPaintStyle,
	        hoverPaintStyle: endpointHoverStyle,
	        connectorHoverStyle: connectorHoverStyle,
	        dragOptions: {},
	        overlays: [
                ["Label", {
                    location: [0.5, 1.5],
                    cssClass: "endpointSourceLabel"
                }]
	        ]
	    },
	    // the definition of target endpoints (will appear when the user drags a connection) 
	    targetEndpoint = {
	        endpoint: "Dot",
	        paintStyle: {
	            strokeStyle: "#61B7CF",
	            fillStyle: "transparent",
	            radius: 7,
	            lineWidth: 3
	        },
	        isSource: true,
	        isTarget: true,
	        connector: ["Flowchart", { stub: [40, 60], gap: 10, cornerRadius: 5, alwaysRespectStubs: true }],
	        connectorStyle: connectorPaintStyle,
	        hoverPaintStyle: endpointHoverStyle,
	        connectorHoverStyle: connectorHoverStyle,
	        dragOptions: {},
	        overlays: [
                ["Label", {
                    location: [0.5, 1.5],
                    cssClass: "endpointSourceLabel"
                }]
	        ]
	    },

        init = function (connection)
        {
            connection.getOverlay("label").setLabel(connection.sourceId.substring(15) + "-" + connection.targetId.substring(15));
            connection.bind("editCompleted", function (o)
            {
                if (typeof console != "undefined")
                    console.log("connection edited. path is now ", o.path);
            });
        };

	    var _addEndpoints = function (toId, sourceAnchors, targetAnchors)
	    {
	        for (var i = 0; i < sourceAnchors.length; i++)
	        {
	            var sourceUUID = toId + sourceAnchors[i];
	            instance.addEndpoint(toId, sourceEndpoint, { anchor: sourceAnchors[i], uuid: sourceUUID });
	        }
	        for (var j = 0; j < targetAnchors.length; j++)
	        {
	            var targetUUID = toId + targetAnchors[j];
	            instance.addEndpoint(toId, targetEndpoint, { anchor: targetAnchors[j], uuid: targetUUID });
	        }
	    };


		// suspend drawing and initialise.
		instance.doWhileSuspended(function() {										

			// bind to connection/connectionDetached events, and update the list of connections on screen.
			instance.bind("connection", function(info, originalEvent) {
				updateConnections(info.connection);
			});
			instance.bind("connectionDetached", function(info, originalEvent) {
				updateConnections(info.connection, true);
			});

			// configure some drop options for use by all endpoints.
			var exampleDropOptions = {
				tolerance:"touch",
				hoverClass:"dropHover",
				activeClass:"dragActive"
			};

			// make .window divs draggable
			instance.draggable(jsPlumb.getSelector(".drag-drop .window"));

		    //dodanie pukntow
			for (var i = 0; i < 5; i++)
			{
			    _addEndpoints("block " + i, ["TopCenter", "BottomCenter"], ["LeftMiddle", "RightMiddle"]);
			}
			//_addEndpoints("block2", ["TopCenter", "BottomCenter"], ["LeftMiddle", "RightMiddle"]);

            //dodanie polaczen
			instance.connect({ uuids: ["block 1BottomCenter", "block 2TopCenter"], editable: true });

		});

			
	});	
})();