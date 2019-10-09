import * as React from "react";
import * as PropTypes from "prop-types";
import Button from "react-uwp/Button";
import Toggle from "react-uwp/Toggle";
import SplitView from "react-uwp/SplitView"
import DropDownMenu from "react-uwp/DropDownMenu";

export interface SimpleExampleState {
    expanded?: boolean;
    displayMode?: "compact" | "overlay";
}

export default class MyComponent extends React.Component<{}, SimpleExampleState> {
    static contextTypes = { theme: PropTypes.object };
    context: { theme: ReactUWP.ThemeType };

    state: SimpleExampleState = {
        expanded: true,
        displayMode: "compact"
    };
    render() {
        const { expanded, displayMode } = this.state;

        return (
            <div>
                <Button tooltip="Mini Tooltip">
                    First
                </Button>

                <SplitView
                    defaultExpanded={expanded}
                    displayMode={displayMode}
                    onClosePane={() => {
                        this.setState({ expanded: false });
                    }}
                    style={{
                        width: "85%",
                        margin: "20px auto",
                        height: 640
                    }}>
                    <div>
                        <Toggle
                            label="Toggle SplitView"
                            defaultToggled={expanded}
                            background="none"
                            style={{ margin: 20 }}
                            onToggle={nextExpanded => {
                                this.setState({ expanded: nextExpanded });
                            }}
                        />
                    </div>
                    <SplitViewPane>
                        SplitViewPane
                    </SplitViewPane>
                </SplitView>
            </div>

        )
    }
}
